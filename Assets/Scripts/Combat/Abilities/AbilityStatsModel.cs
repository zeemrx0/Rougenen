using System;
using System.Collections.Generic;
using UnityEngine;

namespace LNE.Combat.Abilities
{
  [Serializable]
  public class AbilityStatsModel
  {
    public AbilityStatsData BaseStats { get; set; }

    private List<AbilityUpgradeData> _upgrades;

    public bool IsPassive { get; private set; }

    public bool UseOnStart { get; private set; }

    public LayerMask IgnoreLayers { get; private set; }

    public float Damage { get; private set; }

    public float CooldownTime { get; private set; }

    public float Range { get; private set; }

    public bool DestroyProjectileOnCollision { get; private set; }

    public float ProjectileSpeed { get; private set; }

    public float ProjectileAliveRange { get; private set; }

    public int ProjectileQuantity { get; private set; }

    public float ProjectileSpawnDelay { get; private set; }

    public AbilityStatsModel()
    {
      BaseStats = null;
      _upgrades = new List<AbilityUpgradeData>();
    }

    public AbilityStatsModel(AbilityStatsData stats)
    {
      BaseStats = stats;
      _upgrades = new List<AbilityUpgradeData>();
      Init();
    }

    private void Init()
    {
      IsPassive = BaseStats.IsPassive;
      UseOnStart = BaseStats.UseOnStart;
      IgnoreLayers = BaseStats.IgnoreLayers;
      Damage = BaseStats.Damage;
      CooldownTime = BaseStats.CooldownTime;
      Range = BaseStats.Range;
      DestroyProjectileOnCollision = BaseStats.DestroyProjectileOnCollision;
      ProjectileSpeed = BaseStats.ProjectileSpeed;
      ProjectileAliveRange = BaseStats.ProjectileAliveRange;
      ProjectileQuantity = BaseStats.ProjectileQuantity;
      ProjectileSpawnDelay = BaseStats.ProjectileSpawnDelay;
    }

    public void Upgrade(AbilityUpgradeData upgradeData)
    {
      _upgrades.Add(upgradeData);
      ApplyUpgrades();
    }

    public void ApplyUpgrades()
    {
      float UpgradeDamageValue = 0f;
      float UpgradeDamagePercentage = 0f;
      float UpgradeCooldownTimeValue = 0f;
      float UpgradeCooldownTimePercentage = 0f;
      float UpgradeRangeValue = 0f;
      float UpgradeRangePercentage = 0f;
      float UpgradeProjectileSpeedValue = 0f;
      float UpgradeProjectileSpeedPercentage = 0f;
      float UpgradeProjectileAliveRangeValue = 0f;
      float UpgradeProjectileAliveRangePercentage = 0f;
      float UpgradeProjectileQuantityValue = 0f;
      float UpgradeProjectileQuantityPercentage = 0f;
      float UpgradeProjectileSpawnDelayValue = 0f;
      float UpgradeProjectileSpawnDelayPercentage = 0f;

      foreach (var upgrade in _upgrades)
      {
        UpgradeDamageValue += upgrade.Damage.ByValue;
        UpgradeDamagePercentage += upgrade.Damage.ByPercentage;
        UpgradeCooldownTimeValue += upgrade.CooldownTime.ByValue;
        UpgradeCooldownTimePercentage += upgrade.CooldownTime.ByPercentage;
        UpgradeRangeValue += upgrade.Range.ByValue;
        UpgradeRangePercentage += upgrade.Range.ByPercentage;
        UpgradeProjectileSpeedValue += upgrade.ProjectileSpeed.ByValue;
        UpgradeProjectileSpeedPercentage += upgrade
          .ProjectileSpeed
          .ByPercentage;
        UpgradeProjectileAliveRangeValue += upgrade
          .ProjectileAliveRange
          .ByValue;
        UpgradeProjectileAliveRangePercentage += upgrade
          .ProjectileAliveRange
          .ByPercentage;
        UpgradeProjectileQuantityValue += upgrade.ProjectileQuantity.ByValue;
        UpgradeProjectileQuantityPercentage += upgrade
          .ProjectileQuantity
          .ByPercentage;
        UpgradeProjectileSpawnDelayValue += upgrade
          .ProjectileSpawnDelay
          .ByValue;
        UpgradeProjectileSpawnDelayPercentage += upgrade
          .ProjectileSpawnDelay
          .ByPercentage;
      }

      Damage =
        BaseStats.Damage
        + UpgradeDamageValue
        + BaseStats.Damage * UpgradeDamagePercentage / 100;

      CooldownTime =
        BaseStats.CooldownTime
        - UpgradeCooldownTimeValue
        - BaseStats.CooldownTime * UpgradeCooldownTimePercentage / 100;

      Range =
        BaseStats.Range
        + UpgradeRangeValue
        + BaseStats.Range * UpgradeRangePercentage / 100;

      ProjectileSpeed =
        BaseStats.ProjectileSpeed
        + UpgradeProjectileSpeedValue
        + BaseStats.ProjectileSpeed * UpgradeProjectileSpeedPercentage / 100;

      ProjectileAliveRange =
        BaseStats.ProjectileAliveRange
        + UpgradeProjectileAliveRangeValue
        + BaseStats.ProjectileAliveRange
          * UpgradeProjectileAliveRangePercentage
          / 100;

      ProjectileQuantity = (int)(
        BaseStats.ProjectileQuantity
        + UpgradeProjectileQuantityValue
        + BaseStats.ProjectileQuantity
          * UpgradeProjectileQuantityPercentage
          / 100
      );

      ProjectileSpawnDelay =
        BaseStats.ProjectileSpawnDelay
        - UpgradeProjectileSpawnDelayValue
        - BaseStats.ProjectileSpawnDelay
          * UpgradeProjectileSpawnDelayPercentage
          / 100;
    }
  }
}
