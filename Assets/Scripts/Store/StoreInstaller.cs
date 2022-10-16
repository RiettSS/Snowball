using UnityEngine;
using Zenject;

namespace Store
{
    public class StoreInstaller : MonoInstaller
    {
        [SerializeField] private StoreSlotViewFactory _viewFactory;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StoreSlotViewFactory>().FromInstance(_viewFactory).AsSingle();
            Container.Bind<IStoreSlotFactory>().To<StoreSlotFactory>().AsSingle();
            Container.Bind<IStoreSlotProvider>().To<StoreSlotProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<Store>().AsSingle();
        }
    }
}