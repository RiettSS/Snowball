using InputServices;
using UnityEngine;
using Zenject;

namespace Installers.SceneContext
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private InputServiceAndroid _inputServiceDesktopPrefab;
        
        public override void InstallBindings()
        {
            var inputService = Container.InstantiatePrefabForComponent<InputServiceAndroid>(_inputServiceDesktopPrefab);
            Container.Bind<IInputService>().To<InputServiceAndroid>().FromInstance(inputService).AsSingle();
            Container.BindInterfacesAndSelfTo<InputEventListener>().AsSingle();
        }
    }
}
