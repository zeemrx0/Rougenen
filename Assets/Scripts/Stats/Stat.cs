using System;
using UnityEngine;

namespace LNE.GameStats
{
  [Serializable]
  public class Stat
  {
    [field: SerializeField]
    public string Name { get; set; }

    [field: SerializeField]
    public float Value { get; set; }
  }
}
