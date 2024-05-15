using LNE.Utilities.Constants;
using UnityEngine;
using Zenject;

namespace LNE.Core
{
  public class MainMenu : MonoBehaviour
  {
    #region Injected
    private GameSceneManager _gameSceneManager;
    #endregion

    [Inject]
    public void Construct(GameSceneManager gameSceneManager)
    {
      _gameSceneManager = gameSceneManager;
    }

    public void StartChallenge()
    {
      _gameSceneManager.LoadScene(
        SceneName.ChallengeScene,
        new LoadSceneModel(),
        true
      );
    }
  }
}
