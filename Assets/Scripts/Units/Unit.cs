using UnityEngine;

namespace LNE.Units
{
  public class Unit : MonoBehaviour
  {
    [field: SerializeField]
    public UnitStatsData UnitStatsData { get; private set; }

    public Animator Animator { get; private set; }

    private void Awake()
    {
      Animator = GetComponent<Animator>();
    }
  }
}
