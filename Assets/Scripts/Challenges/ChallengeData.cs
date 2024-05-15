using System.Collections.Generic;
using UnityEngine;

namespace LNE.Challenges
{
  [CreateAssetMenu(
    fileName = "_ChallengeData",
    menuName = "Challenges/Challenge",
    order = 0
  )]
  public class ChallengeData : ScriptableObject
  {
    [field: SerializeField]
    public List<EnemyWaveData> EnemyWaves { get; private set; }

    public EnemyWaveData GetEnemyWave(int index)
    {
      return EnemyWaves[index];
    }
  }
}
