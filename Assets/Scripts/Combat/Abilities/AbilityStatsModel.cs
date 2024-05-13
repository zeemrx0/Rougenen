// using System;
// using System.Collections.Generic;
// using LNE.Utilities.Constants;
// using UnityEngine;

// namespace LNE.Combat.Abilities
// {
//   [Serializable]
//   public class AbilityStatsModel
//   {
//     public AbilityStatsData BaseStats { get; set; }

//     private List<AbilityUpgradeData> _upgrades;

//     public AbilityStatsModel()
//     {
//       BaseStats = null;
//       _upgrades = new List<AbilityUpgradeData>();
//     }

//     public AbilityStatsModel(AbilityStatsData stats)
//     {
//       BaseStats = stats;
//       _upgrades = new List<AbilityUpgradeData>();
//       Init();
//     }

//     private void Init() { }

//     public float GetStat(string name)
//     {
//       return BaseStats.Get(name);
//     }

//     public void Upgrade(AbilityUpgradeData upgradeData)
//     {
//       _upgrades.Add(upgradeData);
//       ApplyUpgrades();
//     }

//     public void ApplyUpgrades() { }
//   }
// }
