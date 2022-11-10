using System;
using Model;
using View;
using Zenject;

namespace Presenter
{
    public class ObstaclePresenter : IInitializable, IDisposable
    {
        private readonly ObstacleView _view;
        private readonly Obstacle _model;
        private readonly CollisionHandlerPresenter _collisionHandlerPresenter;

        public ObstaclePresenter(Obstacle model, ObstacleView view)
        {
            _view = view;
            _model = model;
        }
        
        public void Initialize()
        {
            _view.OnCollisionDetected += _model.Collide;
            _model.OnSmash += _view.Smash;
        }

        public void Dispose()
        {
            _view.OnCollisionDetected -= _model.Collide;
            _model.OnSmash -= _view.Smash;
        }
    }
}
