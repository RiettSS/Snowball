using Model;
using Presenter;
using UnityEngine;
using View;
using Zenject;

namespace Installers.SceneContext
{
    public class IndicatorInstaller : MonoInstaller
    {
        [SerializeField] private IndicatorView _view;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<IndicatorView>().FromInstance(_view).AsSingle();
            Container.BindInterfacesAndSelfTo<LevelIndicator>().AsSingle();
            Container.BindInterfacesAndSelfTo<IndicatorPresenter>().AsSingle();
        }
    }
}
