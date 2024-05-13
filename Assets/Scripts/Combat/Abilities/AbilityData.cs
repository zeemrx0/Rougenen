using LNE.GameStats;
using LNE.Utilities;
using LNE.Utilities.Constants;
using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat.Abilities
{
  [CreateAssetMenu(
    fileName = DefaultFileName,
    menuName = "Abilities/Ability",
    order = 0
  )]
  public class AbilityData : ScriptableObjectWithId
  {
    public const string DefaultFileName = "_AbilityData";

    [field: SerializeField]
    public Sprite Icon { get; private set; }

    [SerializeField]
    private AbilityTargetingStrategyData _targetingStrategy;

    [SerializeField]
    private AbilityEffectStrategyData _effectStrategy;

    [field: SerializeField]
    public Stats Stats { get; set; } = new Stats();

    protected override void OnValidate()
    {
      base.OnValidate();
      Stats.BuildDictionary();
    }

    public IObjectPool<Projectile> InitProjectilePool()
    {
      return _effectStrategy.InitProjectilePool();
    }

    public bool Perform(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityModel abilityModel
    )
    {
      if (characterAbilitiesPresenter.GetAbilityCooldownRemainingTime(this) > 0)
      {
        return false;
      }

      string abilityName = GetAbilityName();

      abilityModel.InitialPosition =
        characterAbilitiesPresenter.FindAbilitySpawnPosition(abilityName);

      if (_targetingStrategy == null && _effectStrategy != null)
      {
        _effectStrategy.StartEffect(
          characterAbilitiesPresenter,
          abilityModel,
          abilityModel.ProjectilePool
        );

        return true;
      }

      _targetingStrategy.StartTargeting(
        characterAbilitiesPresenter,
        abilityModel,
        () =>
        {
          OnTargetAcquired(
            characterAbilitiesPresenter,
            abilityModel,
            abilityModel.ProjectilePool
          );
        }
      );

      return true;
    }

    public void OnTargetAcquired(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityModel abilityModel,
      IObjectPool<Projectile> projectilePool
    )
    {
      characterAbilitiesPresenter.StartCooldown(
        this,
        abilityModel.GetStat(StatName.CooldownTime)
      );

      _effectStrategy.StartEffect(
        characterAbilitiesPresenter,
        abilityModel,
        projectilePool
      );
    }

    private string GetAbilityName()
    {
      return name.Split(DefaultFileName)[0];
    }

    public float GetStat(string name)
    {
      return Stats.Get(name);
    }

    public void InitStats()
    {
      Stats.Clear();
      Stats.Add(StatName.IsPassive, 0);
      Stats.Add(StatName.UseOnStart, 0);
      Stats.Add(StatName.IgnoreLayers, 0);

      Stats.Add(StatName.Damage, 0);
      Stats.Add(StatName.Range, 0);
      Stats.Add(StatName.CooldownTime, 0);

      Stats.Add(StatName.DestroyProjectileOnCollision, 0);
      Stats.Add(StatName.ProjectileSpeed, 0);
      Stats.Add(StatName.ProjectileAliveRange, 1000000000f);
      Stats.Add(StatName.ProjectileQuantity, 0);
      Stats.Add(StatName.ProjectileSpawnDelay, 0);
    }
  }
}
