using UnityEngine;

namespace LNE.Inputs
{
  public class PlayerInputManager : MonoBehaviour
  {
    public bool IsInitialized { get; private set; } = false;

    public Vector2 TargetingDirection { get; set; }

    [SerializeField]
    private Joystick _moveJoystick;

    public Vector2 MoveInput
    {
      get { return _moveJoystick.Direction; }
    }
  }
}
