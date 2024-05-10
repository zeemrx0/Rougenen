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
    private AbilityTargetingStrategyData _targetingStrategy;

    [SerializeField]
    private AbilityEffectStrategyData _effectStrategy;

    [SerializeField]
    private AbilityStatsData _abilityStatsData;

    public bool IsPassive => _abilityStatsData.IsPassive;

    public bool UseOnStart => _abilityStatsData.UseOnStart;

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
  }
}
