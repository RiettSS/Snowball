using System;
using Model;
using Model.BallModel;
using UnityEngine;
using Zenject;

namespace Presenter
{
    public class BallPresenter : IInitializable, IDisposable
    {
        private Ball _ball;
        private BallView _view;

        public BallPresenter(Ball ball, BallView view)
        {
            _ball = ball;
            _view = view;
        }
        
        public void Initialize()
        {
            _ball.OnMovementStarted += _view.StartMovement;
            _ball.OnMovementStopped += _view.StopMovement;
            _ball.OnMoveLeft += _view.MoveLeft;
            _ball.OnMoveRight += _view.MoveRight;
            _ball.OnUpgrade += _view.Upgrade;
            _ball.OnSmashed += _view.Smash;
        }

        public void Dispose()
        {
            _ball.OnMovementStarted -= _view.StartMovement;
            _ball.OnMovementStopped -= _view.StopMovement;
            _ball.OnMoveLeft -= _view.MoveLeft;
            _ball.OnMoveRight -= _view.MoveRight;
            _ball.OnUpgrade -= _view.Upgrade;
            _ball.OnSmashed -= _view.Smash;
        }
    }
}
