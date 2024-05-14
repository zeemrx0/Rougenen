using System.Collections.Generic;
using UnityEngine;

namespace LNE.GameChallenge
{
  [CreateAssetMenu(
    fileName = "_GameLevelData",
    menuName = "Game Level/Level",
    order = 0
  )]
  public class GameLevelData : ScriptableObject
  {
    [field: SerializeField]
    public int WaveCount { get; private set; }

    [field: SerializeField]
    public int TimeBetweenWaves { get; private set; }

    [field: SerializeField]
    public List<GameLevelUnit> Units { get; private set; }
  }
}
