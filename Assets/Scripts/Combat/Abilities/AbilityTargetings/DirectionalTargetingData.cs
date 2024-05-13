using System;
using LNE.Characters;
using LNE.Utilities.Constants;
using UnityEngine;

namespace LNE.Combat.Abilities
{
  [CreateAssetMenu(
    fileName = DefaultFileName,
    menuName = "Abilities/Targeting/Directional",
    order = 0
  )]
  public class DirectionalTargetingData : AbilityTargetingStrategyData
  {
    public const string DefaultFileName = "_DirectionalTargetingData";

    public override void StartTargeting(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityModel abilityModel,
      Action onTargetAcquired
    )
    {
      GetTargetDirection(characterAbilitiesPresenter, abilityModel);
      onTargetAcquired?.Invoke();
    }

    private Vector2 GetTargetDirection(
      CharacterAbilitiesPresenter characterAbilitiesPresenter,
      AbilityModel abilityModel
    )
    {
      RaycastHit2D[] hits = Physics2D.CircleCastAll(
        characterAbilitiesPresenter.transform.position,
        abilityModel.GetStat(StatName.Range),
        Vector2.zero,
        0f
      );

      foreach (RaycastHit2D hit in hits)
      {
        hit.transform.TryGetComponent<Character>(out Character character);

        if (
          character != null
          && character.gameObject != characterAbilitiesPresenter.gameObject
        )
        {
          abilityModel.TargetingDirection = (
            character.transform.position
            - characterAbilitiesPresenter.transform.position
          ).normalized;
        }
      }
      return Vector2.zero;
    }
  }
}
