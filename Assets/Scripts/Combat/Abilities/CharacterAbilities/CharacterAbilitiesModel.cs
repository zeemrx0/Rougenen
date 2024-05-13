using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LNE.Combat.Abilities
{
  public class CharacterAbilitiesModel
  {
    private Dictionary<string, AbilityModel> _abilitiesModels =
      new Dictionary<string, AbilityModel>();

    private Dictionary<string, float> _cooldownTimers =
      new Dictionary<string, float>();
    private Dictionary<string, float> _initialCooldownTimers =
      new Dictionary<string, float>();

    public CharacterAbilitiesModel(List<AbilityData> abilityDataList)
    {
      Init(abilityDataList);
    }

    public AbilityModel GetAbilityModel(AbilityData abilityData)
    {
      return _abilitiesModels[abilityData.Id];
    }

    public void Init(List<AbilityData> abilityDataList)
    {
      _abilitiesModels = new Dictionary<string, AbilityModel>();

      for (int i = 0; i < abilityDataList.Count; ++i)
      {
        AbilityData abilityData = abilityDataList[i];

        _abilitiesModels[abilityData.Id] = new AbilityModel();
      }
    }

    public void CoolDownAbilities()
    {
      foreach (var abilityData in _cooldownTimers.Keys.ToList())
      {
        if (_cooldownTimers[abilityData] > 0)
        {
          _cooldownTimers[abilityData] -= Time.deltaTime;

          if (_cooldownTimers[abilityData] < 0)
          {
            _cooldownTimers.Remove(abilityData);
            _initialCooldownTimers.Remove(abilityData);
          }
        }
      }
    }

    public void StartCooldown(AbilityData abilityData, float cooldownTime)
    {
      if (_cooldownTimers.ContainsKey(abilityData.Id))
      {
        return;
      }

      _cooldownTimers.Add(abilityData.Id, cooldownTime);
      _initialCooldownTimers.Add(abilityData.Id, cooldownTime);
    }

    public float GetAbilityCooldownRemainingTime(AbilityData abilityData)
    {
      if (_cooldownTimers.ContainsKey(abilityData.Id))
      {
        return _cooldownTimers[abilityData.Id];
      }

      return 0;
    }

    public float GetAbilityCooldownInitialTime(AbilityData abilityData)
    {
      if (_initialCooldownTimers.ContainsKey(abilityData.Id))
      {
        return _initialCooldownTimers[abilityData.Id];
      }

      return 0;
    }

    public void UpgradeAbility(AbilityUpgradeData abilityUpgradeData)
    {
      _abilitiesModels[abilityUpgradeData.AbilityData.Id].Upgrade(abilityUpgradeData);
    }
  }
}
