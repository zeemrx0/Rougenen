using System;
using LNE.Combat.Abilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LNE.Challenges
{
  public class EnemyWaveRewardButton : MonoBehaviour
  {
    public event Action<AbilityUpgradeData> OnRewardSelected;

    [SerializeField]
    private TextMeshProUGUI _name;

    [SerializeField]
    private Image _icon;

    private Button _button;
    private AbilityUpgradeData _upgrade;

    private void Awake()
    {
      _button = GetComponent<Button>();
      _button.onClick.AddListener(() =>
      {
        HandleRewardSelected();
      });
    }

    public void SetAbilityUpgradeData(AbilityUpgradeData upgrade)
    {
      _upgrade = upgrade;
      _name.text = upgrade.Name;
    }

    public void HandleRewardSelected()
    {
      OnRewardSelected?.Invoke(_upgrade);
    }
  }
}
