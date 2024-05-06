using UnityEngine;

namespace LNE.Movements
{
  public class CharacterMovementView : MonoBehaviour
  {
    public void Move(Rigidbody2D rigidbody, Vector2 velocity)
    {
      rigidbody.AddForce(velocity);
    }
  }
}
