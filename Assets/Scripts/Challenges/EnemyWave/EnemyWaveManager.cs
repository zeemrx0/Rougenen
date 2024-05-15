using System.Collections.Generic;
using LNE.Combat.Abilities;
using UnityEngine;
using Zenject;

namespace LNE.Challenges
{
  [RequireComponent(typeof(CharacterSpawner))]
  public class EnemyWaveManager : MonoBehaviour
  {
    private CharacterSpawner _spawner;
    private EnemyWaveModel _model;

    private void Awake()
    {
      _spawner = GetComponent<CharacterSpawner>();
    }

    private void Start() { }

    private void Update()
    {
      if (_model == null)
      {
        return;
      }

      if (_model.TimeUntilNextSubWave <= 0f)
      {
        SpawnSubNextWave();
        _model.TimeUntilNextSubWave = _model.Data.TimeBetweenWaves;
      }

      _model.TimeUntilNextSubWave -= Time.deltaTime;
      _model.TimeUntilEndWave -= Time.deltaTime;
    }

    public void StartWave(EnemyWaveData data)
    {
      _model = new EnemyWaveModel(data);
    }

    public void SpawnSubNextWave()
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
