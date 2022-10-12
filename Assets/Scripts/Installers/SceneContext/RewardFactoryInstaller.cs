using Model.DailyReward;
using Model.DailyReward.InformationProvider;
using UnityEngine;
using Zenject;

namespace Installers.SceneContext
{
    public class RewardFactoryInstaller : MonoInstaller
    {
        [SerializeField] private RewardViewFactory _viewFactory;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RewardViewFactory>().FromInstance(_viewFactory).AsSingle();
            Container.Bind<IRewardFactory>().To<RewardFactory>().AsSingle();
            Container.Bind<IRewardProvider>().To<RewardProvider>().AsSingle();
            Container.Bind<IRewardInformatioProvider>().To<InformationProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<DailyRewardService>().AsSingle();
        }
    }
}
