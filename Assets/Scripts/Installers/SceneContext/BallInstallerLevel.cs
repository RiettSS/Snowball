using UnityEngine;
using Zenject;

namespace Installers.SceneContext
{
    public class BallInstallerLevel : MonoInstaller
    {
        [SerializeField] private BallView _prefab;
        [SerializeField] private Transform _spawnPoint;

        public override void InstallBindings()
        {
            
        }
    }
}