using UnityEngine;

namespace LNE.Combat
{
  public class PlayerCharacterHealthPresenter : CharacterHealthPresenter
  {
    protected override void Awake()
    {
      base.Awake();
      _view = GetComponentInChildren<CharacterHealthView>();
    }

    protected override void Die()
    {
      base.Die();

      ((PlayerCharacterHealthView)_view).SetGameOverCanvasActive(true);
    }
  }
}
