using UnityEngine;

namespace LNE.Movements
{
  [CreateAssetMenu(
    fileName = "_CharacterMovementData",
    menuName = "Movements/Character Movement"
  )]
  public class CharacterMovementData : ScriptableObject
  {
    [field: SerializeField]
    public float MoveSpeed { get; private set; } = 20f;

    [field: SerializeField]
    public float MaxMoveSpeed { get; private set; } = 40f;
  }
}
