using Model;
using Zenject;

namespace Installers.SceneContext
{
    public class TutorialInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Tutorial>().AsSingle();
        }
    }
}
