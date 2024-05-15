using System;
using System.Collections;
using LNE.Units;
using UnityEngine;

namespace LNE.Combat
{
  public abstract class CharacterHealthPresenter : MonoBehaviour
  {
    public event Action OnDie;

    protected CharacterHealthView _view;
    protected CharacterHealthModel _model = new CharacterHealthModel();
    protected Unit _unit;

    protected virtual void Awake()
    {
      _unit = GetComponentInChildren<Unit>();
    }

    protected virtual void Start()
    {
      _model.MaxHealth = _unit.Stats.MaxHealth;
      _model.CurrentHealth = _unit.Stats.MaxHealth;
    }

    public void TakeDamage(float damage)
    {
      _model.CurrentHealth -= damage;
      if (_model.CurrentHealth <= 0)
      {
        _model.CurrentHealth = 0;
        Die();
      }
      _view.SetHealthSliderValue(_model.CurrentHealth / _model.MaxHealth);
    }

    protected virtual void Die()
    {
      OnDie?.Invoke();
      StartCoroutine(DieCoroutine(1f));
    }

    protected virtual IEnumerator DieCoroutine(float delayTime)
    {
      TryGetComponent(out Collider2D collider);
      if (collider != null)
      {
        collider.enabled = false;
      }

      foreach (Transform child in transform)
      {
        child.gameObject.SetActive(false);
      }

      yield return new WaitForSeconds(delayTime);

      Destroy(gameObject);

      yield return null;
    }
  }
}
