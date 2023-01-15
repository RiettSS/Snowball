using Model;
using Presenter;
using UnityEngine;
using View;
using Zenject;

namespace Istallers.GameObjectInstaller
{
    public class ObstacleInstaller : MonoInstaller
    {
        [SerializeField] private ObstacleView _view;
        
        public override void InstallBindings()
        {
            Container.Bind<Obstacle>().AsSingle().WithArguments(_view.Level, _view.ScorePerObstacle, _view.Type);
            Container.BindInterfacesAndSelfTo<ObstacleView>().FromInstance(_view).AsSingle();
            Container.BindInterfacesAndSelfTo<ObstaclePresenter>().AsSingle();
        }
    }
}