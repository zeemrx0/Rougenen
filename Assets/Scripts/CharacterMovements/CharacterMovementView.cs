using LNE.Core;
using LNE.Utilities.Constants;
using UnityEngine;

namespace LNE.Movements
{
  public class CharacterMovementView : MonoBehaviour
  {
    private Unit _unit;

    private void Awake()
    {
      _unit = GetComponentInChildren<Unit>();
    }

    public void Move(Rigidbody2D rigidbody, Vector2 velocity)
    {
      rigidbody.AddForce(velocity);
      _unit.Animator.SetFloat(AnimationParameter.MoveSpeed, velocity.magnitude);

      if (velocity.x > 0)
      {
        transform.localScale = new Vector3(1, 1, 1);
      }
      else if (velocity.x < 0)
      {
        transform.localScale = new Vector3(-1, 1, 1);
      }
    }
  }
}
