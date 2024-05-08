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
    [field: SerializeField]
    public float Damage { get; set; } = 0f;

    [field: SerializeField]
    public float CooldownTime { get; set; } = 0f;

    [field: SerializeField]
    public float Range { get; set; } = 0f;

    [field: SerializeField]
    public float ProjectileSpeed { get; set; } = 0f;
  }
}
