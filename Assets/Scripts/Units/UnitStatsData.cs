using UnityEngine;

namespace LNE.Movements
{
  [CreateAssetMenu(
    fileName = "_UnitStatsData",
    menuName = "Units/Unit Stats"
  )]
  public class UnitStatsData : ScriptableObject
  {
    [field: SerializeField]
    public float MoveSpeed { get; private set; } = 20f;

    [field: SerializeField]
    public float MaxMoveSpeed { get; private set; } = 40f;
  }
}
