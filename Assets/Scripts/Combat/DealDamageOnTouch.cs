using LNE.Units;
using UnityEngine;

namespace LNE.Combat
{
  public class DealDamageOnTouch : MonoBehaviour
  {
    private Unit _unit;

    private float _attackCooldown = 0.5f;

    private void Awake()
    {
      _unit = GetComponentInChildren<Unit>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
      if (_attackCooldown <= 0)
      {
        if (
          other.gameObject.TryGetComponent(
            out PlayerCharacterHealthPresenter playerHealth
          )
        )
        {
          playerHealth.TakeDamage(_unit.Stats.AttackDamage);
          _attackCooldown = 1f / _unit.Stats.AttackSpeed;
        }
      }
    }

    private void Update()
    {
      if (_attackCooldown > 0)
      {
        _attackCooldown -= Time.deltaTime;
      }
    }
  }
}
