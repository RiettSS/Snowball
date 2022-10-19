using System;
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
        private Wallet _levelWallet;

        public CollisionHandler(Ball ball, IScaler ballScaler, Wallet wallet)
        {
            _ball = ball;
            _ballScaler = ballScaler;
            _wallet = wallet;

            _levelWallet = new Wallet(0);
        }
        
        public void Handle(Obstacle obstacle)
        {
            if (obstacle.Level <= _ball.Level)
            {
                obstacle.Smash();
            }
            else
            {
                _levelWallet = new Wallet(0);
            }
            
            _ballScaler.Handle(obstacle);
        }

        public void Handle(Coin coin)
        {
            _levelWallet.AddCoins(coin.Cost);
            coin.Release();
        }

        public void Handle(Finish finish)
        {
            _wallet.AddCoins(_levelWallet.Coins);
            _wallet.SaveCurrencies();
            _levelWallet = new Wallet(0);
            _ball.StopMovement();
            OnFinished?.Invoke();
        }
    }
}
