using System.Collections.Generic;

namespace LNE.Challenges
{
  public class EnemyWaveModel
  {
    public EnemyWaveData Data { get; set; }
    public List<EnemySubWaveUnit> Units { get; set; } =
      new List<EnemySubWaveUnit>();
    public int CurrentSubWave { get; set; } = 0;
    public float TimeUntilNextSubWave { get; set; } = 0f;
    public float TimeUntilEndWave { get; set; } = 0f;

    public EnemyWaveModel()
    {
      Units = new List<EnemySubWaveUnit>();
      CurrentSubWave = 0;
    }

    public EnemyWaveModel(EnemyWaveData gameLevelData)
    {
      Data = gameLevelData;
      TimeUntilEndWave = gameLevelData.Duration;
      Units = new List<EnemySubWaveUnit>();
      for (int i = 0; i < gameLevelData.EnemySubWaveUnits.Count; i++)
      {
        Units.Add((EnemySubWaveUnit)gameLevelData.EnemySubWaveUnits[i].Clone());
      }
    }
  }
}
