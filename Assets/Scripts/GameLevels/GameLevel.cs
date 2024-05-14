using UnityEngine;

namespace LNE.GameLevels
{
  [RequireComponent(typeof(CharacterSpawner))]
  public class GameLevel : MonoBehaviour
  {
    [SerializeField]
    private GameLevelData _data;

    private CharacterSpawner _spawner;
    private GameLevelModel _model = new GameLevelModel();

    private float _timeUntilNextWave = 0f;

    private void Awake()
    {
      _spawner = GetComponent<CharacterSpawner>();
    }

    private void Start()
    {
      _model = new GameLevelModel(_data);
    }

    private void Update()
    {
      _timeUntilNextWave -= Time.deltaTime;

      if (_timeUntilNextWave <= 0f)
      {
        SpawnNextWave();
        _timeUntilNextWave = _data.TimeBetweenWaves;
      }
    }

    public void SpawnNextWave()
    {
      _model.CurrentWave++;

      if (_model.CurrentWave >= _data.WaveCount)
      {
        return;
      }

      foreach (GameLevelUnit unit in _model.Units)
      {
        int remainingWaves = _data.WaveCount - _model.CurrentWave;

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
