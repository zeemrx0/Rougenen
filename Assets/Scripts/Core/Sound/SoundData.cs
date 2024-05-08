using UnityEngine;

namespace LNE.Core
{
  [CreateAssetMenu(fileName = "_SoundData", menuName = "Core/Sound", order = 0)]
  public class SoundData : ScriptableObject
  {
    [field: SerializeField]
    public AudioClip AudioClip { get; private set; }

    [field: Range(0, 5)]
    [field: SerializeField]
    public float Volume { get; private set; } = 1f;
  }
}
