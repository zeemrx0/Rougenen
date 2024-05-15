using LNE.Core;
using LNE.Utilities.Constants;
using UnityEngine;

namespace LNE.Combat
{
  public class PlayerCharacterHealthPresenter : CharacterHealthPresenter
  {
    [SerializeField]
    private GameOverPopup _gameOverPopup;

    protected override void Awake()
    {
      base.Awake();
      _view = GetComponentInChildren<CharacterHealthView>();
    }

    protected override void Die()
    {
      base.Die();
      _gameOverPopup.Show(GameString.GameOver, GameString.TryBetterNextTime);
    }
  }
}
