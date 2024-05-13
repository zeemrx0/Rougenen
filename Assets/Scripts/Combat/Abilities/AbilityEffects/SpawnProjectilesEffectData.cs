using System.Collections;
using LNE.Characters;
using LNE.Core;
using LNE.GameStats;
using LNE.Utilities.Constants;
using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat.Abilities
{
  [CreateAssetMenu(
    fileName = DefaultFileName,
    menuName = "Abilities/Effects/Spawn Projectiles",
    order = 0
  )]
  public class SpawnProjectilesEffectData : AbilityEffectStrategyData
  {
    public const string DefaultFileName = "_SpawnProjectiles_EffectData";

    [SerializeField]
    private Projectile _projectile;

    [SerializeField]
    private SoundData _onHitSound;

    [SerializeField]
    private VFX _onHitVFX;

    private void OnValidate()
    {
      Stats.BuildDictionary();
    }

    public void InitStats()
    {
      Stats.Clear();
      Stats.Add(StatName.DestroyProjectileOnCollision, 0);
      Stats.Add(StatName.IsProjectileOrbit, 0);
      Stats.Add(StatName.ProjectileSpeed, 0);
      Stats.Add(StatName.ProjectileAliveRange, 1000000000f);
      Stats.Add(StatName.ProjectileQuantity, 0);
      Stats.Add(StatName.ProjectileSpawnDelay, 0);
    }

    public override void StartEffect(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityModel abilityModel,
      IObjectPool<Projectile> projectilePool
    )
    {
      if (abilityModel.GetStat(StatName.IsProjectileOrbit) == 1)
      {
        SpawnOrbitProjectiles(characterAbilitiesPresenter, abilityModel);
      }
      else
      {
        SpawnStraightProjectiles(characterAbilitiesPresenter, abilityModel);
      }
    }

    private void SpawnStraightProjectiles(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityModel abilityModel
    )
    {
      characterAbilitiesPresenter.StartCoroutine(
        SpawnStraightProjectilesCoroutine(
          characterAbilitiesPresenter,
          abilityModel
        )
      );
    }

    private IEnumerator SpawnStraightProjectilesCoroutine(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityModel abilityModel
    )
    {
      for (
        int i = 0;
        i < abilityModel.GetStat(StatName.ProjectileQuantity);
        i++
      )
      {
        SpawnStraightProjectile(
          characterAbilitiesPresenter,
          abilityModel.Stats,
          abilityModel.TargetingDirection
            * abilityModel.GetStat(StatName.ProjectileSpeed)
        );

        yield return new WaitForSeconds(
          abilityModel.GetStat(StatName.ProjectileSpawnDelay)
        );
      }
    }

    private void SpawnStraightProjectile(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      Stats stats,
      Vector2 velocity
    )
    {
      Projectile projectile = Instantiate(_projectile);

      projectile.Owner = characterAbilitiesPresenter.GetComponent<Character>();
      projectile.Stats = stats;
      projectile.OnHitSound = _onHitSound;
      projectile.OnHitVFX = _onHitVFX;
      projectile.transform.position = characterAbilitiesPresenter
        .transform
        .position;
      projectile.SetVelocity(velocity);
      projectile.SetGravityScale(0);
    }

    private void SpawnOrbitProjectiles(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityModel abilityModel
    )
    {
      for (
        int i = 0;
        i < (int)abilityModel.GetStat(StatName.ProjectileQuantity);
        i++
      )
      {
        float angle =
          i * 360f / abilityModel.GetStat(StatName.ProjectileQuantity);
        SpawnOrbitProjectile(
          characterAbilitiesPresenter,
          abilityModel.Stats,
          angle
        );
      }
    }

    private void SpawnOrbitProjectile(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      Stats stats,
      float angle
    )
    {
      Projectile projectile = Instantiate(_projectile);

      projectile.Owner =
        characterAbilitiesPresenter.gameObject.GetComponent<Character>();
      projectile.Stats = stats;
      projectile.OnHitSound = _onHitSound;
      projectile.OnHitVFX = _onHitVFX;
      projectile.StartOrbit(angle);
      projectile.SetGravityScale(0);
    }
  }
}
