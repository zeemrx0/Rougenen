using Zenject;

namespace LNE.Challenges
{
  public class ChallengeInstaller : MonoInstaller<ChallengeInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<ChallengeManager>().FromComponentInHierarchy().AsSingle();
      Container.Bind<EnemyWaveManager>().FromComponentInHierarchy().AsSingle();

    }
  }
}
