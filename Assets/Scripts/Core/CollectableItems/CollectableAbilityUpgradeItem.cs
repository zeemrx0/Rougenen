using LNE.Combat.Abilities;
using UnityEngine;

namespace LNE.Core
{
  public class CollectableAbilityUpgradeItem : CollectableItem
  {
    [SerializeField]
    private AbilityUpgradeData _abilityUpgradeData;

    public override bool Collect(GameObject other)
    {
      other.TryGetComponent(
        out PlayerCharacterAbilitiesPresenter playerCharacterAbilitiesPresenter
      );

      if (playerCharacterAbilitiesPresenter == null)
      {
        return false;
      }

      playerCharacterAbilitiesPresenter?.UpgradeAbility(_abilityUpgradeData);

      return true;
    }
  }
}
