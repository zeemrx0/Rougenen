using LNE.Characters;
using LNE.Core;
using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat.Abilities
{
  [CreateAssetMenu(
    fileName = DefaultFileName,
    menuName = "Abilities/Effects/Orbit",
    order = 0
  )]
  public class OrbitEffectData : EffectStrategyData
  {
    public const string DefaultFileName = "_Orbit_EffectData";

    [SerializeField]
    private Projectile _projectilePrefab;

    [SerializeField]
    private SoundData _projectSound;

    public override void StartEffect(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityStatsData abilityStatsData,
      AbilityModel abilityModel,
      IObjectPool<Projectile> projectilePool
    )
    {
      string abilityName = GetAbilityName(DefaultFileName);
      abilityModel.InitialPosition =
        characterAbilitiesPresenter.FindAbilitySpawnPosition(abilityName);

      Projectile projectile = Instantiate(_projectilePrefab);

      projectile.AbilityStatsData = abilityStatsData;
      projectile.SetGravityScale(0);
      projectile.transform.position =
        abilityModel.InitialPosition + Vector2.left * abilityStatsData.Range;
      projectile.Owner =
        characterAbilitiesPresenter.gameObject.GetComponent<Character>();

      projectile.RotateAroundOwner(abilityStatsData.ProjectileSpeed);

      // Vector2 velocity =
      //   projectile.transform.right * abilityStatsData.ProjectileSpeed;

      // projectile.SetVelocity(
      //   velocity + characterAbilitiesPresenter.GetCurrentVelocity()
      // );

      // projectile.transform.rotation = Quaternion.LookRotation(velocity);
    }
  }
}
