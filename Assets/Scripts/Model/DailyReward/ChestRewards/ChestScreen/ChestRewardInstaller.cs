using UnityEngine;
using Zenject;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class ChestRewardInstaller : MonoInstaller
    {
        [SerializeField] private ChestSlotViewFactory _viewFactory;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ChestReward>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChestSlotViewFactory>().FromInstance(_viewFactory).AsSingle();
            Container.BindInterfacesAndSelfTo<ChestSlotFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<SlotProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<PrizeMachine>().AsSingle();
        }
    }
}