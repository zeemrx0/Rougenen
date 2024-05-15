using LNE.Utilities.Constants;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LNE.Challenges
{
  public class EnemyWaveInfoUI : MonoBehaviour
  {
    [SerializeField]
    private Slider _waveProgressSlider;

    [SerializeField]
    private TextMeshProUGUI _currentWaveIndexText;

    public void SetWaveProgress(float progress)
    {
      _waveProgressSlider.value = progress;
    }

    public void SetCurrentWaveIndex(int index)
    {
      _currentWaveIndexText.text = $"{GameString.Wave} {index}";
    }
  }
}
