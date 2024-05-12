using System;
using UnityEngine;

namespace LNE.Combat.Abilities
{
  [Serializable]
  public class AbilityUpgradeProperty
  {
    [field: SerializeField]
    public float ByValue { get; set; }

    [field: SerializeField]
    public float ByPercentage { get; set; }

    public AbilityUpgradeProperty()
    {
      ByValue = 0f;
      ByPercentage = 0f;
    }

    public AbilityUpgradeProperty(float byValue, float byPercentage)
    {
      ByValue = byValue;
      ByPercentage = byPercentage;
    }
  }
}
