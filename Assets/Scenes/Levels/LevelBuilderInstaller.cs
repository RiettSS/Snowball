using LevelLoading;
using Zenject;

public class LevelBuilderInstaller : MonoInstaller
{ 
    public override void InstallBindings()
    { 
        Container.BindInterfacesAndSelfTo<LevelBuilder>().AsSingle().NonLazy();
    }
}
