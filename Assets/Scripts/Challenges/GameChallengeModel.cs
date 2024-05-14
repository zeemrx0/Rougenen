namespace LNE.GameChallenge
{
  public class GameChallengeModel
  {
    public GameChallengeData Data { get; set; }

    public int CurrentLevel { get; set; } = 0;

    public GameLevelData CurrentLevelData => Data.Levels[CurrentLevel];

    public GameChallengeModel() { }

    public GameChallengeModel(GameChallengeData gameChallengeData)
    {
      Data = gameChallengeData;
    }

    public void NextLevel()
    {
      CurrentLevel++;
    }
  }
}
