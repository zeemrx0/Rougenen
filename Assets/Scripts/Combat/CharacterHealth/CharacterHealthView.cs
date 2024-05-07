using UnityEngine;

namespace LNE.Combat
{
  public abstract class CharacterHealthView : MonoBehaviour
  {
    protected CharacterHealthUIView _characterHealthUIView;

    private void Awake()
    {
      _characterHealthUIView = GetComponentInChildren<CharacterHealthUIView>();
    }

    public void SetHealth(float health)
    {
      _characterHealthUIView.SetHealth(health);
    }
  }
}
