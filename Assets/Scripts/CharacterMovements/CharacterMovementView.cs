using LNE.Utilities.Constants;
using UnityEngine;

namespace LNE.Movements
{
  public class CharacterMovementView : MonoBehaviour
  {
    [SerializeField]
    private Animator _animator;

    public void Move(Rigidbody2D rigidbody, Vector2 velocity)
    {
      rigidbody.AddForce(velocity);
      _animator.SetFloat(AnimationParameter.MoveSpeed, velocity.magnitude);

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
