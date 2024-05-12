using UnityEngine;

namespace LNE.Combat.Abilities
{
  public class PlayerCharacterAbilitiesPresenter : CharacterAbilitiesPresenter
  {
    protected override void Awake()
    {
      base.Awake();
      _view = GetComponent<PlayerCharacterAbilitiesView>();
    }

    public void UpgradeAbility(AbilityUpgradeData abilityUpgradeData)
    {
      _model.UpgradeAbility(abilityUpgradeData);
    }
  }
}
