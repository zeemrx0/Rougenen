using UnityEngine;

namespace LNE.Core
{
  [RequireComponent(typeof(AudioSource))]
  public class SoundPlayer : MonoBehaviour
  {
    private AudioSource _audioSource;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    public void Play(SoundData soundData)
    {
      _audioSource.clip = soundData.AudioClip;
      _audioSource.volume = soundData.Volume;
      _audioSource.Play();
    }

    public float PlayOneShot(SoundData soundData)
    {
      _audioSource.PlayOneShot(soundData.AudioClip, soundData.Volume);
      return soundData.AudioClip.length;
    }
  }
}
