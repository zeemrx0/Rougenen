using UnityEngine;
using UnityEngine.UI;

namespace LNE.Combat
{
  public class CharacterHealthUIView : MonoBehaviour
  {
    [SerializeField]
    protected Slider _slider;

    public void SetHealthSliderValue(float health)
    {
      _slider.value = health;
    }
  }
}
