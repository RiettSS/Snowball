using BallSkinLoader;
using Zenject;

namespace Installers.ProjectContext
{
    public class SkinStorageInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SkinStorage>().AsSingle();
        }
    }
}