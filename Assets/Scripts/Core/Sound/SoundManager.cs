using LNE.Utilities.Constants;
using UnityEngine;
using UnityEngine.Audio;

namespace LNE.Core
{
  public class SoundManager : MonoBehaviour
  {
    // [SerializeField]
    // private AudioMixer _audioMixer;

    // private SettingsModel _settingsDataModel;

    // public void Init(SettingsModel settingsDataModel)
    // {
    //   _settingsDataModel = settingsDataModel;
    //   SetMasterVolume(_settingsDataModel.MasterVolume);
    // }

    // public void SetMasterVolume(float volume)
    // {
    //   _settingsDataModel.MasterVolume = volume;

    //   float dbVolume = -80 * (1 - _settingsDataModel.MasterVolume);

    //   _audioMixer.SetFloat(AudioParameter.MasterVolume, dbVolume);
    // }

    // public float ToggleSound()
    // {
    //   if (_settingsDataModel.MasterVolume > 0)
    //   {
    //     SetMasterVolume(0);
    //   }
    //   else
    //   {
    //     SetMasterVolume(1);
    //   }

    //   return _settingsDataModel.MasterVolume;
    // }
  }
}
