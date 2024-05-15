using System.Collections.Generic;
using LNE.Utilities.Constants;
using TMPro;
using UnityEngine;
using Zenject;

namespace LNE.Core
{
  public class GameOverPopup : MonoBehaviour
  {
    [SerializeField]
    private List<TextMeshProUGUI> _titles;

    [SerializeField]
    private TextMeshProUGUI _message;

    #region Injected
    private GameSceneManager _gameSceneManager;
    #endregion

    [Inject]
    public void Construct(GameSceneManager gameSceneManager)
    {
      _gameSceneManager = gameSceneManager;
    }

    public void Show(string title, string message)
    {
      foreach (TextMeshProUGUI t in _titles)
      {
        t.text = title;
      }
      _message.text = message;

      gameObject.SetActive(true);
    }

    public void Hide()
    {
      gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
      _gameSceneManager.LoadScene(SceneName.MainMenu, null, false);
    }
  }
}
