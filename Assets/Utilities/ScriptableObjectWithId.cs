using UnityEngine;

namespace LNE.Utilities
{
  public abstract class ScriptableObjectWithId
    : ScriptableObject,
      IContainsId
  {
    public string Id { get; set; }

    protected virtual void Awake()
    {
      if (string.IsNullOrEmpty(Id))
      {
        GenerateId();
      }
    }

    protected virtual void OnValidate()
    {
      if (string.IsNullOrEmpty(Id))
      {
        GenerateId();
      }
    }

    public void GenerateId()
    {
      Id = System.Guid.NewGuid().ToString();
    }
  }
}
