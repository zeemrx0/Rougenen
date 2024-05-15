namespace LNE.Challenges
{
  public class ChallengeModel
  {
    public ChallengeData Data { get; set; }

    public int CurrentWave { get; set; } = -1;

    public EnemyWaveData CurrentEnemyWaveData => Data.EnemyWaves[CurrentWave];

    public float TimeUntilNextWave { get; set; } = 0;

    public ChallengeModel()
    {
      CurrentWave = -1;
    }

    public ChallengeModel(ChallengeData gameChallengeData)
    {
      CurrentWave = -1;
      Data = gameChallengeData;
    }
  }
}
