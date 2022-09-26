using UI.Popup;
using UnityEngine;
using Zenject;

namespace Installers.GameObjectContext
{
    public class PopUpInstaller : MonoInstaller
    {
        [SerializeField] private PopUpView _view;
        
        public override void InstallBindings()
        {
            Container.Bind<PopUpView>().FromInstance(_view).AsSingle();
            Container.BindInterfacesAndSelfTo<PopUp>().AsSingle().WithArguments(_view.Type);
            Container.BindInterfacesAndSelfTo<PopUpPresenter>().AsSingle();
        }
    }
}
