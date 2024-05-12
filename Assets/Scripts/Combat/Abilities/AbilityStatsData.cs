using UnityEngine;

namespace LNE.Combat.Abilities
{
  [CreateAssetMenu(
    fileName = "_AbilityStatsData",
    menuName = "Abilities/Ability Stats",
    order = 0
  )]
  public class AbilityStatsData : ScriptableObject
  {
    [field: Header("General")]
    [field: SerializeField]
    public bool IsPassive { get; private set; }

    [field: SerializeField]
    public bool UseOnStart { get; private set; }

    [field: SerializeField]
    public LayerMask IgnoreLayers { get; set; }

    [field: SerializeField]
    public float Damage { get; set; }

    [field: SerializeField]
    public float CooldownTime { get; set; }

    [field: SerializeField]
    public float Range { get; set; }

    [field: Header("Projectile")]
    [field: SerializeField]
    public bool DestroyProjectileOnCollision { get; set; }

    [field: SerializeField]
    public float ProjectileSpeed { get; set; }

    [field: SerializeField]
    public float ProjectileAliveRange { get; set; }

    [field: SerializeField]
    public int ProjectileQuantity { get; set; }

    [field: SerializeField]
    public float ProjectileSpawnDelay { get; set; }

    public AbilityStatsData()
    {
      IsPassive = true;
      UseOnStart = false;
      IgnoreLayers = 0;
      Damage = 0f;
      CooldownTime = 0f;
      Range = 0f;
      DestroyProjectileOnCollision = false;
      ProjectileSpeed = 0f;
      ProjectileAliveRange = 1000000000f;
      ProjectileQuantity = 0;
      ProjectileSpawnDelay = 0.5f;
    }
  }
}
