using Camera;
using UnityEngine;
using Zenject;

namespace Installers.SceneContext
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CameraMovement _cameraMovement;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CameraMovement>().FromInstance(_cameraMovement).AsSingle();
        }
    }
}