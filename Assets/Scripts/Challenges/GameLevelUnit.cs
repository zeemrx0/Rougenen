using System;
using LNE.Characters;
using UnityEngine;

namespace LNE.GameChallenge
{
  [Serializable]
  public class GameLevelUnit : ICloneable
  {
    [field: SerializeField]
    public Character Character { get; set; }

    [field: SerializeField]
    public int Quantity { get; set; }

    [field: SerializeField]
    public int StartWave { get; set; }

    public object Clone()
    {
      return new GameLevelUnit
      {
        Character = Character,
        Quantity = Quantity,
        StartWave = StartWave
      };
    }
  }
}
