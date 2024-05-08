using LNE.Core;
using UnityEngine;

namespace LNE.Combat.Abilities
{
  public abstract class CharacterAbilitiesView : MonoBehaviour
  {
    protected SoundPlayer _soundPlayer;

    protected virtual void Awake()
    {
      // _soundPlayer = GetComponent<SoundPlayer>();
    }

    public float PlaySoundOneShot(SoundData soundData)
    {
      return 0;
      // return _soundPlayer.PlayOneShot(soundData);
    }
  }
}
