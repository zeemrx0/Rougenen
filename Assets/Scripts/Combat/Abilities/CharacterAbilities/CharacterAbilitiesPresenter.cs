using System.Collections.Generic;
using LNE.Characters;
using LNE.Core;
using UnityEngine;

namespace LNE.Combat.Abilities
{
  public abstract class CharacterAbilitiesPresenter : MonoBehaviour
  {
    public string Id { get; protected set; }

    [SerializeField]
    protected List<AbilityData> _abilityDataList;

    protected Character _character;

    protected CharacterAbilitiesView _view;
    protected CharacterAbilitiesModel _model;

    public Vector2 Origin => _character.AbilitySpawnPosition;

    protected virtual void Awake()
    {
      Id = gameObject.GetInstanceID().ToString();
      _character = GetComponent<Character>();
    }

    protected virtual void Start()
    {
      _model = new CharacterAbilitiesModel(_abilityDataList);

      foreach (var abilityData in _abilityDataList)
      {
        if (abilityData.IsPassive)
        {
          abilityData.Perform(this, _model.GetAbilityModel(abilityData));
        }
      }
    }

    protected virtual void Update()
    {
      _model.CoolDownAbilities();

      foreach (AbilityData abilityData in _abilityDataList)
      {
        if (abilityData.IsPassive && !abilityData.UseOnStart)
        {
          abilityData.Perform(this, _model.GetAbilityModel(abilityData));
        }
      }
    }

    public Vector2 FindAbilitySpawnPosition(string abilityName)
    {
      return _character.AbilitySpawnPosition;
    }

    public Vector2 GetCurrentVelocity()
    {
      return gameObject.GetComponent<Rigidbody2D>().velocity;
    }

    public float PlaySoundOneShot(SoundData soundData)
    {
      return _view.PlaySoundOneShot(soundData);
    }

    #region Model Methods
    public float GetAbilityCooldownRemainingTime(AbilityData abilityData)
    {
      return _model.GetAbilityCooldownRemainingTime(abilityData);
    }

    public void StartCooldown(AbilityData abilityData, float cooldownTime)
    {
      _model.StartCooldown(abilityData, cooldownTime);
    }
    #endregion
  }
}
