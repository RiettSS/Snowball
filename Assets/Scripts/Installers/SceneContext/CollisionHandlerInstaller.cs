using Model;
using Presenter;
using Zenject;

namespace Installers.SceneContext
{
    public class CollisionHandlerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CollisionHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<CollisionHandlerPresenter>().AsSingle();
        }
    }
}
