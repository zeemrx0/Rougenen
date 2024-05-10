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
    private LayerMask _ignoreLayers;

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
        SpawnProjectile(
          characterAbilitiesPresenter.gameObject.GetComponent<Character>(),
          abilityStatsData,
          angle
        );
      }
    }

    private void SpawnProjectile(
      Character owner,
      AbilityStatsData abilityStatsData,
      float angle
    )
    {
      Projectile projectile = Instantiate(_projectile);

      projectile.Owner = owner;
      projectile.AbilityStatsData = abilityStatsData;
      projectile.IgnoreLayers = _ignoreLayers;
      projectile.OnHitSound = _onHitSound;
      projectile.OnHitVFX = _onHitVFX;
      projectile.StartOrbit(angle);
      projectile.SetGravityScale(0);
    }
  }
}
