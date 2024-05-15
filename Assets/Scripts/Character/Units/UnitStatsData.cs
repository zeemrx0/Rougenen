using UnityEngine;

namespace LNE.Units
{
  [CreateAssetMenu(fileName = "_UnitStatsData", menuName = "Units/Unit Stats")]
  public class UnitStatsData : ScriptableObject
  {
    [field: SerializeField]
    public float MaxHealth { get; private set; } = 100f;

    [field: SerializeField]
    private float _moveSpeed = 120f;

    public float MoveSpeed => _moveSpeed * 10f;

    [field: SerializeField]
    public float MaxMoveSpeed { get; private set; } = 160f;

    [field: SerializeField]
    public float AttackDamage { get; private set; } = 5f;

    [field: SerializeField]
    public float AttackSpeed { get; private set; } = 1f;
  }
}
