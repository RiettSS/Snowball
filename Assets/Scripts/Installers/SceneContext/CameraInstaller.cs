using Camera;
using UnityEngine;
using Zenject;

namespace Installers.SceneContext
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private BallFollower _ballFollower;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BallFollower>().FromInstance(_ballFollower).AsSingle();
        }
    }
}