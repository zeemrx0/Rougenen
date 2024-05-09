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
      string abilityName = GetAbilityName(DefaultFileName);
      abilityModel.InitialPosition =
        characterAbilitiesPresenter.FindAbilitySpawnPosition(abilityName);

      Projectile projectile = Instantiate(_projectile);

      projectile.Owner =
        characterAbilitiesPresenter.gameObject.GetComponent<Character>();
      projectile.AbilityStatsData = abilityStatsData;
      projectile.IgnoreLayers = _ignoreLayers;
      projectile.OnHitSound = _onHitSound;
      projectile.OnHitVFX = _onHitVFX;
      projectile.IsOrbit = true;

      projectile.SetGravityScale(0);
      projectile.transform.position =
        abilityModel.InitialPosition + Vector2.left * abilityStatsData.Range;
    }
  }
}
