using BallSkinLoader;
using Zenject;

namespace Installers.ProjectContext
{
    public class SkinsInformationProviderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISkinsInformationProvider>().To<SkinsInformationProvider>().AsSingle();
        }
    }
}