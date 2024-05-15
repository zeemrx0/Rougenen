namespace LNE.Challenges
{
  public class ChallengeModel
  {
    public ChallengeData Data { get; set; }

    public int CurrentWave { get; set; } = 0;

    public EnemyWaveData CurrentEnemyWaveData => Data.EnemyWaves[CurrentWave];

    public ChallengeModel() { }

    public ChallengeModel(ChallengeData gameChallengeData)
    {
      Data = gameChallengeData;
    }

    public void NextLevel()
    {
      CurrentWave++;
    }
  }
}
