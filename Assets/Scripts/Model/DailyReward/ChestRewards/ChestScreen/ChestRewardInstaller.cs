using UnityEngine;
using Zenject;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class ChestRewardInstaller : MonoInstaller
    {
        [SerializeField] private ChestSlotViewFactory _viewFactory;
        [SerializeField] private PrizeMachineView _prizeMachineView;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ChestReward>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChestSlotViewFactory>().FromInstance(_viewFactory).AsSingle();
            Container.BindInterfacesAndSelfTo<ChestSlotFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<SlotProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<PrizeMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<PrizeMachineView>().FromInstance(_prizeMachineView).AsSingle();
            Container.BindInterfacesAndSelfTo<PrizeMachinePresenter>().AsSingle();
        }
    }
}