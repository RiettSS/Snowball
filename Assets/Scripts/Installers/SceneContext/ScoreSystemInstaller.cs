using Model;
using Zenject;

namespace Installers.SceneContext
{
    public class ScoreSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScoreSystem>().AsSingle();
        }
    }
}
