using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LNE.Core
{
  public class GameOverPopup : MonoBehaviour
  {
    [SerializeField]
    private List<TextMeshProUGUI> _titles;

    [SerializeField]
    private TextMeshProUGUI _message;

    public void Show(string title, string message)
    {
      foreach (TextMeshProUGUI t in _titles)
      {
        t.text = title;
      }
      _message.text = message;

      gameObject.SetActive(true);
    }

    public void Hide()
    {
      gameObject.SetActive(false);
    }
  }
}
