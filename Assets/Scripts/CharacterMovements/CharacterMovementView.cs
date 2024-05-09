using LNE.Units;
using LNE.Utilities.Constants;
using UnityEngine;

namespace LNE.Movements
{
  public class CharacterMovementView : MonoBehaviour
  {
    private Unit _unit;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
      _unit = GetComponentInChildren<Unit>();
      _spriteRenderer = _unit.GetComponent<SpriteRenderer>();
    }

    public void Move(Rigidbody2D rigidbody, Vector2 velocity)
    {
      rigidbody.AddForce(velocity);
      _unit.Animator.SetFloat(AnimationParameter.MoveSpeed, velocity.magnitude);

      if (velocity.x > 0)
      {
        _spriteRenderer.flipX = false;
      }
      else if (velocity.x < 0)
      {
        _spriteRenderer.flipX = true;
      }
    }
  }
}
