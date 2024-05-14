using UnityEngine;
using Zenject;

namespace LNE.GameChallenge
{
  [RequireComponent(typeof(CharacterSpawner))]
  public class GameLevelManager : MonoBehaviour
  {
    #region Injected
    private GameChallengeManager _challengeManager;
    #endregion

    private CharacterSpawner _spawner;
    private GameLevelModel _model = new GameLevelModel();

    private float _timeUntilNextWave = 0f;

    [Inject]
    public void Construct(GameChallengeManager challengeManager)
    {
      _challengeManager = challengeManager;
    }

    private void Awake()
    {
      _spawner = GetComponent<CharacterSpawner>();
    }

    private void Start()
    {
      _model = new GameLevelModel(_challengeManager.CurrentLevelData);
    }

    private void Update()
    {
      _timeUntilNextWave -= Time.deltaTime;

      if (_timeUntilNextWave <= 0f)
      {
        SpawnNextWave();
        _timeUntilNextWave = _model.Data.TimeBetweenWaves;
      }
    }

    public void SpawnNextWave()
    {
      _model.CurrentWave++;

      if (_model.CurrentWave >= _model.Data.WaveCount)
      {
        return;
      }

      foreach (GameLevelUnit unit in _model.Units)
      {
        int remainingWaves = _model.Data.WaveCount - _model.CurrentWave;

        if (_model.CurrentWave >= unit.StartWave)
        {
          int spawnQuantity = unit.Quantity / remainingWaves;
          unit.Quantity -= spawnQuantity;

          for (int i = 0; i < spawnQuantity; i++)
          {
            _spawner.Spawn(unit.Character);
          }
        }
      }
    }
  }
}
