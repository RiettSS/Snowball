using Model;
using UI.Popup;
using Zenject;

namespace Installers.SceneContext
{
    public class PopUpShowerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PopUpShower>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIEventListener>().AsSingle();
        }
    }
}
