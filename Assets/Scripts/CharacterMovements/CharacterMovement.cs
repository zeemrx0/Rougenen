using System;
using UnityEngine;

namespace LNE.Movements
{
  public abstract class CharacterMovementPresenter : MonoBehaviour
  {
    protected Rigidbody2D _rigidbody;
    protected CharacterMovementData _data;

    protected virtual void Awake() { }

    protected virtual void FixedUpdate() { }

    protected void LimitVelocity()
    {
      if (Math.Abs(_rigidbody.velocity.magnitude) > _data.MaxMoveSpeed)
      {
        float fraction = _data.MaxMoveSpeed / _rigidbody.velocity.magnitude;

        _rigidbody.velocity = new Vector2(
          _rigidbody.velocity.x * fraction,
          _rigidbody.velocity.y * fraction
        );
      }
    }
  }
}
