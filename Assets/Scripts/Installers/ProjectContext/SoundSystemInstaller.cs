using Sound;
using UnityEngine;
using Zenject;

public class SoundSystemInstaller : MonoInstaller
{
    [SerializeField] private SoundConfig _soundConfig;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SoundSystem>()
            .AsSingle()
            .WithArguments(_soundConfig)
            .NonLazy();
    }
}
