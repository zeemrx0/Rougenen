using LNE.Movements;
using UnityEngine;

namespace LNE.Core
{
  public class Character : MonoBehaviour
  {
    [field: SerializeField]
    public CharacterMovementData MovementData { get; private set; }
  }
}
