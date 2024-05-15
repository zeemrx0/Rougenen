using System.Collections.Generic;
using UnityEngine;

namespace LNE.Challenges
{
  [CreateAssetMenu(
    fileName = "_EnemyWaveData",
    menuName = "Challenges/Enemy Wave",
    order = 0
  )]
  public class EnemyWaveData : ScriptableObject
  {
    [field: SerializeField]
    public float Duration { get; private set; }

    [field: SerializeField]
    public float TimeBetweenWaves { get; private set; }

    [field: SerializeField]
    public List<EnemySubWaveUnit> EnemySubWaveUnits { get; private set; }
  }
}
