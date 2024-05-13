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
      AbilityModel abilityModel,
      IObjectPool<Projectile> projectilePool
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
        SpawnProjectile(characterAbilitiesPresenter, abilityModel.Stats, angle);
      }
    }

    private void SpawnProjectile(
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
