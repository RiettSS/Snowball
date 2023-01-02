using Signals;
using UnityEngine;
using Zenject;

public class AppEntryPoint
{
    private readonly SignalBus _signalBus;
    private readonly DiContainer _container;

    [Inject]
    public AppEntryPoint(
        SignalBus signalBus,
        DiContainer container
    )
    {
        _signalBus = signalBus;
        _container = container;
        
        _container.DeclareSignal<AppStartedSignal>();
        _container.DeclareSignal<ButtonPressedSignal>();
    }
}
