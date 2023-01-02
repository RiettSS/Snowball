using Zenject;

public class AppEntryPointInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        
        Container.Bind<AppEntryPoint>().AsSingle().WithArguments(Container).NonLazy();
    }
}
