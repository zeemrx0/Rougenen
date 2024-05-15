using UnityEngine;

namespace LNE.Combat
{
  public class PlayerCharacterHealthView : CharacterHealthView
  {
    [SerializeField]
    private Canvas _gameOverCanvas;

    public void SetGameOverCanvasActive(bool active)
    {
      _gameOverCanvas.gameObject.SetActive(active);
    }
  }
}
