using Zenject;

namespace LNE.GameChallenge
{
  public class GameChallengeInstaller : MonoInstaller<GameChallengeInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<GameChallengeManager>().FromComponentInHierarchy().AsSingle();
      Container.Bind<GameLevelManager>().FromComponentInHierarchy().AsSingle();

    }
  }
}
