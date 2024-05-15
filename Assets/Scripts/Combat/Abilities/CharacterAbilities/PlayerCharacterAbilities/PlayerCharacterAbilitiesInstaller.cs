using LNE.Combat.Abilities;
using Zenject;

namespace LNE.Challenges
{
  public class PlayerCharacterAbilitiesInstaller
    : MonoInstaller<PlayerCharacterAbilitiesInstaller>
  {
    public override void InstallBindings()
    {
      Container
        .Bind<PlayerCharacterAbilitiesPresenter>()
        .FromComponentInHierarchy()
        .AsSingle();
    }
  }
}
