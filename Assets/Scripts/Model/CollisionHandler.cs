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
        private readonly Wallet _wallet;

        public CollisionHandler(Ball ball, IScaler ballScaler, Wallet wallet)
        {
            _ball = ball;
            _ballScaler = ballScaler;
            _wallet = wallet;
        }
        
        public void Handle(Obstacle obstacle)
        {
            _ballScaler.Handle(obstacle);
        }

        public void Handle(Coin coin)
        {
            _wallet.AddCoins(coin.Cost);
            Debug.Log("coins in wallet: " + _wallet.Coins);
            coin.Release();
        }

        public void Handle(Finish finish)
        {
            _wallet.SaveCoins();
            _ball.StopMovement();
            OnFinished?.Invoke();
        }
    }
}
