// using LNE.GameStats;
// using LNE.Utilities;
// using LNE.Utilities.Constants;
// using UnityEngine;

// namespace LNE.Combat.Abilities
// {
//   [CreateAssetMenu(
//     fileName = "_AbilityStatsData",
//     menuName = "Abilities/Ability Stats",
//     order = 0
//   )]
//   public class AbilityStatsData : ScriptableObjectWithId
//   {
    

//     public void Init()
//     {
//       Stats = new Stats();
//       Stats.Add(StatName.IsPassive, 0);
//       Stats.Add(StatName.UseOnStart, 0);
//       Stats.Add(StatName.IgnoreLayers, 0);

//       Stats.Add(StatName.Damage, 0);
//       Stats.Add(StatName.Range, 0);
//       Stats.Add(StatName.CooldownTime, 0);

//       Stats.Add(StatName.DestroyProjectileOnCollision, 0);
//       Stats.Add(StatName.ProjectileSpeed, 0);
//       Stats.Add(StatName.ProjectileAliveRange, 0);
//       Stats.Add(StatName.ProjectileQuantity, 0);
//       Stats.Add(StatName.ProjectileSpawnDelay, 0);
//     }

//     public float Get(string name)
//     {
//       return Stats.Get(name).Value;
//     }
//   }
// }
