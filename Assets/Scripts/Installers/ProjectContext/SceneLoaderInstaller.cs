using SceneLoading;
using Zenject;

namespace Installers.ProjectContext
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelLoader>().AsSingle();
        }
    }
}