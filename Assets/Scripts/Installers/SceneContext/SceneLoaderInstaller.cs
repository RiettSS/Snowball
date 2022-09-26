using UnityEngine;
using Zenject;

public class SceneLoaderInstaller : MonoInstaller
{
    [SerializeField] private SceneLoader _sceneLoader;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SceneLoader>().FromInstance(_sceneLoader).AsSingle();
    }
}
