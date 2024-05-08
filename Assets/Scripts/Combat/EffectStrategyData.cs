using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat.Abilities
{
  public abstract class EffectStrategyData : ScriptableObject
  {
    public virtual IObjectPool<Projectile> InitProjectilePool()
    {
      return null;
    }

    public abstract void StartEffect(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityStatsData abilityStatsData,
      AbilityModel abilityModel,
      IObjectPool<Projectile> projectilePool
    );

    protected virtual string GetAbilityName(string defaultFileName)
    {
      return name.Split(defaultFileName)[0];
    }
  }
}
