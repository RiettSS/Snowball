using Model;
using Presenter;
using UnityEngine;
using Zenject;

namespace Installers.SceneContext
{
    public class BallInstaller : MonoInstaller
    {
        [SerializeField] private BallView _prefab;
        [SerializeField] private Transform _spawnPoint;

        [SerializeField] private int _pointsPerLevel;
        [SerializeField] private int _maxLevel;

        public override void InstallBindings()
        {
            var ball = Container.InstantiatePrefabForComponent<BallView>(_prefab, _spawnPoint.position, Quaternion.identity, null);
            Container.BindInterfacesAndSelfTo<BallView>().FromInstance(ball).AsSingle();
            Container.BindInterfacesAndSelfTo<Ball>().AsSingle().WithArguments(_maxLevel);
            Container.BindInterfacesAndSelfTo<BallPresenter>().AsSingle();
            Container.Bind<IScaler>().To<DefaultScaler>().AsSingle().WithArguments(_pointsPerLevel);
        }
    }
}
