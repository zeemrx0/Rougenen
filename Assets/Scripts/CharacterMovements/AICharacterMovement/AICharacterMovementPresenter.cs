using UnityEngine;

namespace LNE.Movements
{
  public class AICharacterMovementPresenter : CharacterMovementPresenter
  {
    private AICharacterMovementView _view;

    protected override void Awake()
    {
      base.Awake();

      _view = GetComponent<AICharacterMovementView>();
    }

    protected override void FixedUpdate()
    {
      Vector2 velocity = Vector2.zero;

      _view.Move(_rigidbody, velocity);

      LimitVelocity();
    }
  }
}
