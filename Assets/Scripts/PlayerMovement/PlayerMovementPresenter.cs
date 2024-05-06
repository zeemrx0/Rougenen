using LNE.Inputs;
using UnityEngine;
using Zenject;

public class PlayerMovementPresenter : MonoBehaviour
{
  #region Injected
  private PlayerInputManager _playerInputManager;
  #endregion

  private Rigidbody2D _rigidbody;

  [Inject]
  public void Construct(PlayerInputManager playerInputManager)
  {
    _playerInputManager = playerInputManager;
  }

  private void Awake()
  {
    _rigidbody = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
    _rigidbody.AddForce(
      new Vector2(
        _playerInputManager.MoveInput.x,
        _playerInputManager.MoveInput.y
      )
    );
  }
}
