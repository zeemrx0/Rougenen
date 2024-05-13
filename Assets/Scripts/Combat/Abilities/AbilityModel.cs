using System.Collections.Generic;
using LNE.GameStats;
using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat.Abilities
{
  public class AbilityModel
  {
    public Stats BaseStats { get; private set; } = new Stats();
    public Stats Stats { get; set; } = new Stats();
    public List<Stats> Upgrades { get; set; } = new List<Stats>();
    public IObjectPool<Projectile> ProjectilePool { get; set; }
    public bool IsPerforming { get; set; }
    public bool IsPerformed { get; set; }
    public bool IsCancelled { get; set; }
    public float RemainingCoolDownTime { get; set; }
    public Vector2 InitialPosition { get; set; }
    public Vector2 TargetingPosition { get; set; }
    public Vector2 TargetingDirection { get; set; }
    public int ProjectileQuantity { get; set; }

    public AbilityModel()
    {
      BaseStats = new Stats();
      Stats = new Stats();
      Upgrades = new List<Stats>();
      Reset();
    }

    public void SetBaseStats(Stats stats)
    {
      BaseStats = stats;
      Stats = new Stats(stats);
    }

    public void Reset()
    {
      IsPerforming = false;
      IsPerformed = false;
      IsCancelled = false;
      RemainingCoolDownTime = 0f;
      InitialPosition = Vector2.zero;
      TargetingPosition = Vector2.zero;
      TargetingDirection = Vector2.zero;
      ProjectileQuantity = 0;
    }

    public float GetStat(string name)
    {
      return Stats.Get(name);
    }

    public void AddUpgrade(AbilityUpgradeData upgradeData)
    {
      Upgrades.Add(upgradeData.Stats);
      Stats.Add(upgradeData.Stats);
    }
  }
}
