using LNE.Core;
using LNE.Inputs;
using UnityEngine;
using Zenject;

namespace LNE.Movements
{
  public class PlayerMovementPresenter : CharacterMovementPresenter
  {
    #region Injected
    private PlayerInputManager _playerInputManager;
    #endregion

    private PlayerMovementView _view;

    [Inject]
    public void Construct(PlayerInputManager playerInputManager)
    {
      _playerInputManager = playerInputManager;
    }

    protected override void Awake()
    {
      _rigidbody = GetComponent<Rigidbody2D>();
      _data = GetComponentInChildren<Character>().MovementData;
      _view = GetComponent<PlayerMovementView>();
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
