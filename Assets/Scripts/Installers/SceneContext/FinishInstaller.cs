using Model;
using Presenter;
using UnityEngine;
using View;
using Zenject;

namespace Installers.SceneContext
{
    public class FinishInstaller : MonoInstaller
    {
        [SerializeField] private FinishView _finishView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FinishView>().FromInstance(_finishView).AsSingle();
            Container.BindInterfacesAndSelfTo<Finish>().AsSingle();
            Container.BindInterfacesAndSelfTo<FinishPresenter>().AsSingle();
        }
    }
}
