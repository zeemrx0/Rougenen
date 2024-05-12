using UnityEngine;

namespace LNE.Combat.Abilities
{
  [CreateAssetMenu(
    fileName = "_AbilityUpgradeData",
    menuName = "Abilities/Upgrade",
    order = 0
  )]
  public class AbilityUpgradeData : ScriptableObject
  {
    [field: Header("Information")]
    [field: SerializeField]
    public Sprite Icon { get; private set; }

    [field: SerializeField]
    public string Description { get; private set; }

    [field: SerializeField]
    public AbilityData AbilityData { get; private set; }

    [field: Header("General")]
    [field: SerializeField]
    public AbilityUpgradeProperty Damage { get; set; }

    [field: SerializeField]
    public AbilityUpgradeProperty CooldownTime { get; set; }

    [field: SerializeField]
    public AbilityUpgradeProperty Range { get; set; }

    [field: Header("Projectile")]
    [field: SerializeField]
    public AbilityUpgradeProperty ProjectileSpeed { get; set; }

    [field: SerializeField]
    public AbilityUpgradeProperty ProjectileAliveRange { get; set; }

    [field: SerializeField]
    public AbilityUpgradeProperty ProjectileQuantity { get; set; }

    [field: SerializeField]
    public AbilityUpgradeProperty ProjectileSpawnDelay { get; set; }

    public AbilityUpgradeData()
    {
      Damage = new AbilityUpgradeProperty();
      CooldownTime = new AbilityUpgradeProperty();
      Range = new AbilityUpgradeProperty();
      ProjectileSpeed = new AbilityUpgradeProperty();
      ProjectileAliveRange = new AbilityUpgradeProperty();
      ProjectileQuantity = new AbilityUpgradeProperty();
      ProjectileSpawnDelay = new AbilityUpgradeProperty();
    }
  }
}
