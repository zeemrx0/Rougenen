using LNE.Core;
using LNE.Inputs;
using UnityEngine;
using Zenject;

namespace LNE.Movements
{
  public class PlayerCharacterMovementPresenter : CharacterMovementPresenter
  {
    #region Injected
    private PlayerInputManager _playerInputManager;
    #endregion

    private PlayerCharacterMovementView _view;

    [Inject]
    public void Construct(PlayerInputManager playerInputManager)
    {
      _playerInputManager = playerInputManager;
    }

    protected override void Awake()
    {
      base.Awake();

      _view = GetComponent<PlayerCharacterMovementView>();
    }

    protected override void FixedUpdate()
    {
      Vector2 velocity =
        new Vector2(
          _playerInputManager.MoveInput.x
            * _data.MoveSpeed
            * Time.fixedDeltaTime,
          _playerInputManager.MoveInput.y
            * _data.MoveSpeed
            * Time.fixedDeltaTime
        ) * 10;

      _view.Move(_rigidbody, velocity);

      LimitVelocity();
    }
  }
}
