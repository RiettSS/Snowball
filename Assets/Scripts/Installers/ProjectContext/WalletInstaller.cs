using Model;
using Zenject;

namespace Installers.ProjectContext
{
    public class WalletInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Wallet>().AsSingle().NonLazy();
        }
    }
}
