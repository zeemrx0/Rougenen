using System.Collections.Generic;

namespace LNE.GameChallenge
{
  public class GameLevelModel
  {
    public GameLevelData Data { get; set; }
    public List<GameLevelUnit> Units { get; set; } = new List<GameLevelUnit>();
    public int CurrentWave { get; set; } = 0;

    public GameLevelModel()
    {
      Units = new List<GameLevelUnit>();
      CurrentWave = 0;
    }

    public GameLevelModel(GameLevelData gameLevelData)
    {
      Data = gameLevelData;
      Units = new List<GameLevelUnit>();
      for (int i = 0; i < gameLevelData.Units.Count; i++)
      {
        Units.Add((GameLevelUnit)gameLevelData.Units[i].Clone());
      }
    }
  }
}
