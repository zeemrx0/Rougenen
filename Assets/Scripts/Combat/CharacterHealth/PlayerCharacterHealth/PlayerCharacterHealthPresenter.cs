using LNE.Inputs;
using Zenject;

namespace LNE.Combat
{
  public class PlayerCharacterHealthPresenter : CharacterHealthPresenter
  {
    #region Injected
    private PlayerInputManager _playerInputManager;
    #endregion

    [Inject]
    public void Construct(PlayerInputManager playerInputManager)
    {
      _playerInputManager = playerInputManager;
    }

    protected override void Awake()
    {
      base.Awake();
      _view = GetComponentInChildren<CharacterHealthView>();
    }

    protected override void Die()
    {
      _playerInputManager.Disable();
      base.Die();
    }
  }
}
