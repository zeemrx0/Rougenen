using LNE.GameStats;
using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat.Abilities
{
  public class AbilityModel
  {
    public Stats Stats { get; set; }
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
      Stats = new Stats();
      Reset();
    }

    public AbilityModel(Stats stats)
    {
      Stats = stats;
      Reset();
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

    public void Upgrade(AbilityUpgradeData upgradeData)
    {
      // Stats.Upgrade(upgradeData);
    }
  }
}
