using SceneLoader;
using UnityEngine;
using Zenject;

namespace Installers.ProjectContext
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoaderView _viewPrefab;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader.SceneLoader>().AsSingle();
            var view = Container.InstantiatePrefabForComponent<SceneLoaderView>(_viewPrefab, new Vector3(0,0,0), Quaternion.identity, null);
            Container.BindInterfacesAndSelfTo<SceneLoaderView>().FromInstance(view).AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoaderPresenter>().AsSingle();
        }
    }
}