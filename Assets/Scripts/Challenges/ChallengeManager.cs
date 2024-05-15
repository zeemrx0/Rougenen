using System.Collections.Generic;
using LNE.Combat.Abilities;
using LNE.Core;
using UnityEngine;
using Zenject;

namespace LNE.Challenges
{
  public class ChallengeManager : MonoBehaviour
  {
    [SerializeField]
    private ChallengeData _data;

    [SerializeField]
    private EnemyWaveRewardPopup _enemyWaveRewardPopup;

    [SerializeField]
    private List<AbilityUpgradeData> _waveRewards;

    #region Injected
    private GameSceneManager _gameSceneManager;
    #endregion

    private ChallengeModel _model = new ChallengeModel();
    private EnemyWaveManager _enemyWaveManager;

    public EnemyWaveData CurrentEnemyWaveData => _model.CurrentEnemyWaveData;

    [Inject]
    public void Construct(GameSceneManager gameSceneManager)
    {
      _gameSceneManager = gameSceneManager;
    }

    private void Awake()
    {
      _model = new ChallengeModel(_data);
      _enemyWaveManager = GetComponent<EnemyWaveManager>();
    }

    private void Update()
    {
      if (_model.TimeUntilNextWave <= 0)
      {
        NextWave();
      }

      _model.TimeUntilNextWave -= Time.deltaTime;
    }

    private void NextWave()
    {
      if (_model.CurrentWave >= _model.Data.EnemyWaves.Count - 1)
      {
        EndChallenge();
        return;
      }

      if (_model.CurrentWave >= 0)
      {
        EndWave();
      }

      _model.CurrentWave++;
      _enemyWaveManager.StartWave(CurrentEnemyWaveData, _model.CurrentWave);
      _model.TimeUntilNextWave = CurrentEnemyWaveData.Duration;
    }

    private void EndWave()
    {
      ShowWaveReward();
    }

    public void ShowWaveReward()
    {
      Time.timeScale = 0f;
      List<AbilityUpgradeData> rewards = new List<AbilityUpgradeData>();
      for (int i = 0; i < 3; i++)
      {
        rewards.Add(_waveRewards[Random.Range(0, _waveRewards.Count)]);
      }

      _enemyWaveRewardPopup.gameObject.SetActive(true);
      _enemyWaveRewardPopup.SetRewardButton(rewards);
    }

    private void EndChallenge()
    {
      Debug.Log("Challenge Ended");
    }

    public void TryAgain()
    {
      Time.timeScale = 1f;
      _gameSceneManager.LoadScene(
        _gameSceneManager.CurrentSceneName,
        null,
        false
      );
    }
  }
}
