using LNE.Movements;
using UnityEngine;

namespace LNE.Core
{
  public class Unit : MonoBehaviour
  {
    [field: SerializeField]
    public UnitStatsData MovementData { get; private set; }
  }
}
