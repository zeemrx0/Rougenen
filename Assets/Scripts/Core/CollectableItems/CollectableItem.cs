using UnityEngine;

namespace LNE.Core
{
  public abstract class CollectableItem : MonoBehaviour
  {
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
      if (Collect(other.gameObject))
      {
        Destroy(gameObject);
      }
    }

    public abstract bool Collect(GameObject other);
  }
}
