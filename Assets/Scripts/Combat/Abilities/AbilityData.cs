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
    private Stats _stats = new Stats();

    public Stats Stats
    {
      get
      {
        Stats stats = new Stats();

        stats.Add(_stats);

        if (_effectStrategy != null)
        {
          stats.Add(_effectStrategy.Stats);
        }

        return stats;
      }
    }

    protected override void OnValidate()
    {
      base.OnValidate();
      _stats.BuildDictionary();
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
        PerformAbility(
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
      PerformAbility(characterAbilitiesPresenter, abilityModel, projectilePool);
    }

    private void PerformAbility(
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
      return _stats.Get(name);
    }

    public void InitStats()
    {
      _stats.Clear();
      _stats.Add(StatName.IsPassive, 0);
      _stats.Add(StatName.UseOnStart, 0);
      _stats.Add(StatName.IgnoreLayers, 0);

      _stats.Add(StatName.Damage, 0);
      _stats.Add(StatName.Range, 0);
      _stats.Add(StatName.CooldownTime, 0);
    }
  }
}
