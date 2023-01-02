using UnityEngine;
using Zenject;

public class ObstacleSmashedSoundInstaller : MonoInstaller
{
    [SerializeField] private GameObject _obstacleSmashedAudioSourceTemplate;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ObstacleSmashedSound>().
            AsSingle().WithArguments(_obstacleSmashedAudioSourceTemplate)
            .NonLazy();
    }
}
