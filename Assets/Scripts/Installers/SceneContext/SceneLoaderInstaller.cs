using UnityEngine;
using Zenject;

public class SceneLoaderInstaller : MonoInstaller
{
    [SerializeField] private SceneLoader.SceneLoaderView sceneLoaderView;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SceneLoader.SceneLoaderView>().FromInstance(sceneLoaderView).AsSingle();
    }
}
