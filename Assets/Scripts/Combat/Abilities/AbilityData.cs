using LNE.Utilities;
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
    private TargetingStrategyData _targetingStrategy;

    [SerializeField]
    private AbilityEffectStrategyData _effectStrategy;

    [SerializeField]
    private AbilityStatsData _abilityStatsData;

    [field: SerializeField]
    public bool IsPassive { get; private set; }

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

      if (IsPassive)
      {
        _effectStrategy.StartEffect(
          characterAbilitiesPresenter,
          _abilityStatsData,
          abilityModel,
          abilityModel.ProjectilePool
        );

        return true;
      }

      _targetingStrategy.StartTargeting(
        characterAbilitiesPresenter,
        _abilityStatsData,
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
        _abilityStatsData.CooldownTime
      );

      _effectStrategy.StartEffect(
        characterAbilitiesPresenter,
        _abilityStatsData,
        abilityModel,
        projectilePool
      );
    }

    private string GetAbilityName()
    {
      return name.Split(DefaultFileName)[0];
    }

    public float Range => _abilityStatsData.Range;

    public float ProjectileSpeed => _abilityStatsData.ProjectileSpeed;
  }
}
