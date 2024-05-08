using UnityEngine;
using UnityEngine.Pool;

namespace LNE.Combat.Abilities
{
  public class AbilityModel
  {
    public IObjectPool<Projectile> ProjectilePool { get; set; }
    public bool IsPerforming { get; set; } = false;
    public bool IsPerformed { get; set; } = false;
    public bool IsCancelled { get; set; } = false;
    public float RemainingCoolDownTime { get; set; } = 0f;
    public Vector2 InitialPosition { get; set; }
    public Vector2 TargetPosition { get; set; }
    public Vector2 TargetingDirection { get; set; }

    public void Reset()
    {
      IsPerforming = false;
      IsPerformed = false;
      IsCancelled = false;
      RemainingCoolDownTime = 0f;
      InitialPosition = Vector2.zero;
      TargetPosition = Vector2.zero;
      TargetingDirection = Vector2.zero;
    }
  }
}
