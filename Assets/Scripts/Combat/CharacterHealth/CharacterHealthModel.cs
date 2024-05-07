using System;
using UnityEngine;

namespace LNE.Combat
{
  public class CharacterHealthModel : ICloneable
  {
    [field: SerializeField]
    public float CurrentHealth { get; set; }

    [field: SerializeField]
    public float MaxHealth { get; set; }

    public CharacterHealthModel()
    {
      MaxHealth = 100;
      CurrentHealth = MaxHealth;
    }

    public object Clone()
    {
      return new CharacterHealthModel
      {
        CurrentHealth = CurrentHealth,
        MaxHealth = MaxHealth
      };
    }
  }
}
