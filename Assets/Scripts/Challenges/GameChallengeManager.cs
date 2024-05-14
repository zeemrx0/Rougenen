using LNE.Utilities.Constants;
using UnityEngine;

namespace LNE.GameChallenge
{
  public class GameChallengeManager : MonoBehaviour
  {
    [SerializeField]
    private GameChallengeData _data;

    private GameChallengeModel _model = new GameChallengeModel();

    public GameLevelData CurrentLevelData => _model.CurrentLevelData;

    private void Awake()
    {
      _model = new GameChallengeModel(_data);
      LoadFromFile();
    }

    public void LoadFromFile()
    {
      if (ES3.KeyExists(SavingKey.GameChallenge, SavingPath.GameChallenge))
      {
        _model = ES3.Load<GameChallengeModel>(
          SavingKey.GameChallenge,
          SavingPath.GameChallenge
        );
      }
    }
  }
}
