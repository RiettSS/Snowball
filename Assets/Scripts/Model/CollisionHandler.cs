using System;
using Model.BallModel;
using UI.Popup;
using UnityEngine;

namespace Model
{
    public sealed class CollisionHandler
    {
        public event Action OnFinished;

        private readonly Ball _ball;
        private readonly IScaler _ballScaler;
        private readonly PopUpShower _popUpShower;

        public CollisionHandler(Ball ball, IScaler ballScaler)
        {
            _ball = ball;
            _ballScaler = ballScaler;
        }
        
        public void Handle(Obstacle obstacle)
        {
            _ballScaler.Handle(obstacle);
        }

        public void Handle(Coin coin)
        {
            Debug.Log("collected coin cost is " + coin.Cost);
        }

        public void Handle(Finish finish)
        {
            _ball.StopMovement();
            OnFinished?.Invoke();
        }
    }
}
