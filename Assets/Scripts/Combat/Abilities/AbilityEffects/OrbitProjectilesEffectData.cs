using LNE.Characters;
using LNE.Core;
using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat.Abilities
{
  [CreateAssetMenu(
    fileName = DefaultFileName,
    menuName = "Abilities/Effects/Orbit Projectiles",
    order = 0
  )]
  public class OrbitProjectilesEffectData : AbilityEffectStrategyData
  {
    public const string DefaultFileName = "_OrbitProjectiles_EffectData";

    [SerializeField]
    private Projectile _projectile;

    [SerializeField]
    private SoundData _onHitSound;

    [SerializeField]
    private VFX _onHitVFX;

    public override void StartEffect(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityStatsData abilityStatsData,
      AbilityModel abilityModel,
      IObjectPool<Projectile> projectilePool
    )
    {
      for (int i = 0; i < abilityStatsData.ProjectileQuantity; i++)
      {
        float angle = i * 360f / abilityStatsData.ProjectileQuantity;
        SpawnProjectile(characterAbilitiesPresenter, abilityStatsData, angle);
      }
    }

    private void SpawnProjectile(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityStatsData abilityStatsData,
      float angle
    )
    {
      Projectile projectile = Instantiate(_projectile);

      projectile.Owner =
        characterAbilitiesPresenter.gameObject.GetComponent<Character>();
      projectile.AbilityStatsData = abilityStatsData;
      projectile.OnHitSound = _onHitSound;
      projectile.OnHitVFX = _onHitVFX;
      projectile.StartOrbit(angle);
      projectile.SetGravityScale(0);
    }
  }
}
