using System;
using LNE.Characters;
using UnityEngine;

namespace LNE.Challenges
{
  [Serializable]
  public class EnemySubWaveUnit : ICloneable
  {
    [field: SerializeField]
    public Character Character { get; set; }

    [field: SerializeField]
    public int MinQuantity { get; set; }

    [field: SerializeField]
    public int MaxQuantity { get; set; }

    [field: SerializeField]
    public int StartSubWave { get; set; }

    public object Clone()
    {
      return new EnemySubWaveUnit
      {
        Character = Character,
        MinQuantity = MinQuantity,
        MaxQuantity = MaxQuantity,
        StartSubWave = StartSubWave
      };
    }
  }
}
