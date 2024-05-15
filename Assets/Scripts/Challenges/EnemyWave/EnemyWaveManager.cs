using UnityEngine;
using Zenject;

namespace LNE.Challenges
{
  [RequireComponent(typeof(CharacterSpawner))]
  public class EnemyWaveManager : MonoBehaviour
  {
    #region Injected
    private ChallengeManager _challengeManager;
    #endregion

    private CharacterSpawner _spawner;
    private EnemyWaveModel _model = new EnemyWaveModel();

    [Inject]
    public void Construct(ChallengeManager challengeManager)
    {
      _challengeManager = challengeManager;
    }

    private void Awake()
    {
      _spawner = GetComponent<CharacterSpawner>();
    }

    private void Start()
    {
      _model = new EnemyWaveModel(_challengeManager.CurrentEnemyWaveData);
    }

    private void Update()
    {
      _model.TimeUntilNextSubWave -= Time.deltaTime;
      _model.TimeUntilEndWave -= Time.deltaTime;

      if (_model.TimeUntilEndWave <= 0f)
      {
        EndWave();
      }

      if (_model.TimeUntilNextSubWave <= 0f)
      {
        SpawnNextWave();
        _model.TimeUntilNextSubWave = _model.Data.TimeBetweenWaves;
      }
    }

    private void EndWave()
    {
      Debug.Log("End wave");
    }

    public void SpawnNextWave()
    {
      _model.CurrentSubWave++;

      foreach (EnemySubWaveUnit unit in _model.Units)
      {
        if (_model.CurrentSubWave >= unit.StartSubWave)
        {
          int quantity = Random.Range(unit.MinQuantity, unit.MaxQuantity + 1);

          for (int i = 0; i < quantity; i++)
          {
            _spawner.Spawn(unit.Character);
          }
        }
      }
    }
  }
}
