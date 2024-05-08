using UnityEngine;

namespace LNE.Characters
{
  public class Character : MonoBehaviour
  {
    public Vector2 AbilitySpawnPosition =>
      transform.position + Vector3.up * 0.5f;
  }
}
