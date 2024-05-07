namespace LNE.Combat
{
  public class PlayerCharacterHealthPresenter : CharacterHealthPresenter
  {
    protected override void Awake()
    {
      base.Awake();
      _view = GetComponentInChildren<CharacterHealthView>();
    }
  }
}
