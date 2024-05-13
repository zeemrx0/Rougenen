using LNE.GameStats;
using UnityEngine;

namespace LNE.Combat.Abilities
{
  [CreateAssetMenu(
    fileName = "_AbilityUpgradeData",
    menuName = "Abilities/Upgrade",
    order = 0
  )]
  public class AbilityUpgradeData : ScriptableObject
  {
    [SerializeField]
    private AbilityData _abilityData;

    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public Stats Stats { get; private set; }

    private void OnValidate()
    {
      Stats.BuildDictionary();
    }

    public string AbilityId => _abilityData.Id;
  }
}
