using System.Collections.Generic;
using LNE.Combat.Abilities;
using UnityEngine;
using Zenject;

namespace LNE.Challenges
{
  public class EnemyWaveRewardPopup : MonoBehaviour
  {
    [SerializeField]
    private Transform _rewardButtons;

    [SerializeField]
    private EnemyWaveRewardButton _rewardButtonPrefab;

    #region Injected
    private PlayerCharacterAbilitiesPresenter _playerCharacterAbilitiesPresenter;
    #endregion

    [Inject]
    public void Construct(
      PlayerCharacterAbilitiesPresenter playerCharacterAbilitiesPresenter
    )
    {
      _playerCharacterAbilitiesPresenter = playerCharacterAbilitiesPresenter;
    }

    public void SetRewardButton(List<AbilityUpgradeData> upgrades)
    {
      foreach (Transform child in _rewardButtons)
      {
        Destroy(child.gameObject);
      }

      for (int i = 0; i < upgrades.Count; i++)
      {
        EnemyWaveRewardButton rewardButton = Instantiate(
          _rewardButtonPrefab,
          _rewardButtons
        );
        rewardButton.SetAbilityUpgradeData(upgrades[i]);
        rewardButton.OnRewardSelected += HandleRewardSelected;
      }
    }

    private void HandleRewardSelected(AbilityUpgradeData data)
    {
      _playerCharacterAbilitiesPresenter.UpgradeAbility(data);
      Time.timeScale = 1;
      gameObject.SetActive(false);
    }
  }
}
