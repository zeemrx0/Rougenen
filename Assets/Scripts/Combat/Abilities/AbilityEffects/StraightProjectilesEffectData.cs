using System.Collections;
using LNE.Characters;
using LNE.Core;
using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat.Abilities
{
  [CreateAssetMenu(
    fileName = DefaultFileName,
    menuName = "Abilities/Effects/Straight Projectiles",
    order = 0
  )]
  public class StraightProjectilesEffectData : AbilityEffectStrategyData
  {
    public const string DefaultFileName = "_StraightProjectiles_EffectData";

    [SerializeField]
    private Projectile _projectile;

    [SerializeField]
    private SoundData _onHitSound;

    [SerializeField]
    private VFX _onHitVFX;

    public override IObjectPool<Projectile> InitProjectilePool()
    {
      return new ObjectPool<Projectile>(
        () => Instantiate(_projectile),
        pooledProjectile => pooledProjectile.gameObject.SetActive(true),
        pooledProjectile => pooledProjectile.gameObject.SetActive(false),
        pooledProjectile => Destroy(pooledProjectile.gameObject),
        true,
        10,
        10
      );
    }

    public override void StartEffect(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityStatsData abilityStatsData,
      AbilityModel abilityModel,
      IObjectPool<Projectile> projectilePool
    )
    {
      characterAbilitiesPresenter.StartCoroutine(
        SpawnProjectilesCoroutine(
          characterAbilitiesPresenter,
          abilityStatsData,
          abilityModel
        )
      );
    }

    private IEnumerator SpawnProjectilesCoroutine(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityStatsData abilityStatsData,
      AbilityModel abilityModel
    )
    {
      for (int i = 0; i < abilityStatsData.ProjectileQuantity; i++)
      {
        SpawnProjectile(
          characterAbilitiesPresenter,
          abilityStatsData,
          abilityModel.TargetingDirection * abilityStatsData.ProjectileSpeed
        );

        yield return new WaitForSeconds(abilityStatsData.ProjectileSpawnDelay);
      }
    }

    private void SpawnProjectile(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityStatsData abilityStatsData,
      Vector2 velocity
    )
    {
      Projectile projectile = Instantiate(_projectile);

      projectile.Owner = characterAbilitiesPresenter.GetComponent<Character>();
      projectile.AbilityStatsData = abilityStatsData;
      projectile.OnHitSound = _onHitSound;
      projectile.OnHitVFX = _onHitVFX;
      projectile.transform.position = characterAbilitiesPresenter
        .transform
        .position;
      projectile.SetVelocity(velocity);
      projectile.SetGravityScale(0);
    }
  }
}
