using UnityEngine;

namespace LNE.Combat.Abilities
{
  public class PlayerCharacterAbilitiesPresenter : CharacterAbilitiesPresenter
  {
    private Camera _mainCamera;

    protected override void Awake()
    {
      base.Awake();
      _view = GetComponent<PlayerCharacterAbilitiesView>();
      _mainCamera = Camera.main;
    }

    public Vector3 GetWorldAlignedDirection(Vector2 direction)
    {
      Transform cameraTransform = _mainCamera.transform;
      float cameraAngle = cameraTransform.eulerAngles.y;

      Vector3 alignedDirection =
        Quaternion.Euler(0, cameraAngle, 0)
        * new Vector3(direction.x, 0, direction.y);

      return alignedDirection;
    }
  }
}
