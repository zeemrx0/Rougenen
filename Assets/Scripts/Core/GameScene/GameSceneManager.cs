using System.Collections;
using LNE.Utilities.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace LNE.Core
{
  public class GameSceneManager : MonoBehaviour
  {
    private CanvasGroup _loadSceneCanvas;

    #region Injected
    private ZenjectSceneLoader _zenjectSceneLoader;
    // private LoadSceneModel _loadSceneModel;
    #endregion

    public string CurrentSceneName => SceneManager.GetActiveScene().name;

    [Inject]
    public void Construct(ZenjectSceneLoader zenjectSceneLoader)
    {
      _zenjectSceneLoader = zenjectSceneLoader;
    }

    private void Start()
    {
      StartCoroutine(InitSceneCoroutine());
    }

    private IEnumerator InitSceneCoroutine()
    {
      ShowLoadSceneBackground();

      yield return FadeOut(0.5f);
    }

    public void LoadScene(
      string destinationSceneName,
      LoadSceneModel loadSceneModel,
      bool saveScene
    )
    {
      StartCoroutine(
        LoadSceneCoroutine(destinationSceneName, loadSceneModel, saveScene)
      );
    }

    public IEnumerator LoadSceneCoroutine(
      string destinationSceneName,
      LoadSceneModel loadSceneModel,
      bool saveScene
    )
    {
      // if (saveScene)
      // {
      //   _savingManager.SaveScene();
      // }

      yield return FadeIn(0.5f);

      yield return _zenjectSceneLoader.LoadSceneAsync(
        destinationSceneName,
        LoadSceneMode.Single,
        (container) =>
        {
          container
            .BindInstance(loadSceneModel)
            .WhenInjectedInto<GameSceneManager>();
        }
      );
    }

    public IEnumerator FadeIn(float time)
    {
      _loadSceneCanvas = GameObject
        .FindGameObjectWithTag(TagName.LoadSceneBackground)
        .GetComponent<CanvasGroup>();

      _loadSceneCanvas.gameObject.SetActive(true);

      _loadSceneCanvas.alpha = 0;

      while (_loadSceneCanvas.alpha < 1)
      {
        _loadSceneCanvas.alpha += Time.deltaTime / time;

        yield return null;
      }
    }

    public IEnumerator FadeOut(float time)
    {
      _loadSceneCanvas = GameObject
        .FindGameObjectWithTag(TagName.LoadSceneBackground)
        .GetComponent<CanvasGroup>();

      _loadSceneCanvas.gameObject.SetActive(true);

      _loadSceneCanvas.alpha = 1;

      while (_loadSceneCanvas.alpha > 0)
      {
        _loadSceneCanvas.alpha -= Time.deltaTime / time;
        yield return null;
      }
    }

    public void ShowLoadSceneBackground()
    {
      _loadSceneCanvas = GameObject
        .FindGameObjectWithTag(TagName.LoadSceneBackground)
        .GetComponent<CanvasGroup>();

      _loadSceneCanvas.alpha = 1;
    }

    public void HideLoadSceneBackground()
    {
      _loadSceneCanvas = GameObject
        .FindGameObjectWithTag(TagName.LoadSceneBackground)
        .GetComponent<CanvasGroup>();

      _loadSceneCanvas.alpha = 0;
    }
  }
}
