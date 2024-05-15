using LNE.Utilities.Constants;
using UnityEngine;

namespace LNE.Challenges
{
  public class ChallengeManager : MonoBehaviour
  {
    [SerializeField]
    private ChallengeData _data;

    private ChallengeModel _model = new ChallengeModel();

    public EnemyWaveData CurrentEnemyWaveData => _model.CurrentEnemyWaveData;

    private void Awake()
    {
      _model = new ChallengeModel(_data);
      LoadFromFile();
    }

    public void LoadFromFile()
    {
      if (ES3.KeyExists(SavingKey.GameChallenge, SavingPath.GameChallenge))
      {
        _model = ES3.Load<ChallengeModel>(
          SavingKey.GameChallenge,
          SavingPath.GameChallenge
        );
      }
    }
  }
}
