using System.Collections.Generic;
using LNE.Combat;
using LNE.Combat.Abilities;
using LNE.Core;
using LNE.Inputs;
using LNE.Utilities.Constants;
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

    [SerializeField]
    private GameOverPopup _gameOverPopup;

    [SerializeField]
    private PlayerCharacterHealthPresenter _playerCharacterHealthPresenter;

    #region Injected
    private GameSceneManager _gameSceneManager;
    private PlayerInputManager _playerInputManager;
    #endregion

    private ChallengeModel _model = new ChallengeModel();
    private EnemyWaveManager _enemyWaveManager;
    private Transform _enemiesContainer;
    private bool _isGameOver = false;

    public EnemyWaveData CurrentEnemyWaveData => _model.CurrentEnemyWaveData;

    [Inject]
    public void Construct(
      GameSceneManager gameSceneManager,
      PlayerInputManager playerInputManager
    )
    {
      _gameSceneManager = gameSceneManager;
      _playerInputManager = playerInputManager;
    }

    private void Awake()
    {
      _model = new ChallengeModel(_data);
      _enemyWaveManager = GetComponent<EnemyWaveManager>();
      _enemiesContainer = GameObject.Find(TagName.EnemiesContainer).transform;
    }

    private void OnEnable()
    {
      if (_playerCharacterHealthPresenter != null)
      {
        _playerCharacterHealthPresenter.OnDie += HandlePlayerDie;
      }
    }

    private void OnDisable()
    {
      if (_playerCharacterHealthPresenter != null)
      {
        _playerCharacterHealthPresenter.OnDie -= HandlePlayerDie;
      }
    }

    private void Start()
    {
      _playerInputManager.Enable();
    }

    private void Update()
    {
      if (_isGameOver)
      {
        return;
      }

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
      DestroyAllEnemies();

      _playerInputManager.Disable();
      _gameOverPopup.Show(GameString.YouWin, GameString.YourAreAMonsterHunter);
    }

    private void DestroyAllEnemies()
    {
      foreach (Transform child in _enemiesContainer)
      {
        Destroy(child.gameObject);
      }
    }

    private void HandlePlayerDie()
    {
      if (!_isGameOver)
      {
        _isGameOver = true;
        _gameOverPopup.Show(GameString.GameOver, GameString.TryBetterNextTime);
        DestroyAllEnemies();
      }
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
