using System.Collections.Generic;
using UnityEngine;

namespace LNE.GameChallenge
{
  [CreateAssetMenu(
    fileName = "_GameDifficultyData",
    menuName = "Game/Difficulty",
    order = 0
  )]
  public class GameChallengeData : ScriptableObject
  {
    [field: SerializeField]
    public List<GameLevelData> Levels { get; private set; }

    public GameLevelData GetLevel(int index)
    {
      return Levels[index];
    }
  }
}
