using SceneLoading;
using UnityEngine;
using Zenject;

public class SceneLoaderInstaller : MonoInstaller
{
    [SerializeField] private SceneLoaderView _sceneLoaderView;

    public override void InstallBindings()
    {
        var view = Container.InstantiatePrefabForComponent<SceneLoaderView>(_sceneLoaderView);
        DontDestroyOnLoad(view);
        Container.BindInterfacesAndSelfTo<SceneLoaderView>().FromInstance(view).AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoaderPresenter>().FromNew().AsSingle();
    }
}
