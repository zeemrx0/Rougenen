using UnityEngine;

namespace LNE.Movements
{
  public class AICharacterMovementPresenter : CharacterMovementPresenter
  {
    private AICharacterMovementView _view;

    private Vector2 _direction = Vector2.zero;

    protected override void Awake()
    {
      base.Awake();

      _view = GetComponent<AICharacterMovementView>();
    }

    protected override void FixedUpdate()
    {
      Vector2 velocity = _direction * _data.MoveSpeed * Time.fixedDeltaTime;

      _view.Move(_rigidbody, velocity);

      LimitVelocity();
    }

    public void MoveToPosition(Vector2 position)
    {
      _direction = (position - (Vector2)transform.position).normalized;
    }

    public void Stop()
    {
      _direction = Vector2.zero;
    }
  }
}
