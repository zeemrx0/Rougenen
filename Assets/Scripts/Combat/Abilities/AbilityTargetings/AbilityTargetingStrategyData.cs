using System;
using UnityEngine;

namespace LNE.Combat.Abilities
{
  public abstract class AbilityTargetingStrategyData : ScriptableObject
  {
    public virtual void Init(AbilityModel abilityModel) { }

    public abstract void StartTargeting(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityModel abilityModel,
      Action onTargetAcquired
    );

    protected virtual string GetAbilityName(string defaultFileName)
    {
      return name.Split(defaultFileName)[0];
    }
  }
}
