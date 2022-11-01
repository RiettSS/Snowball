using System;
using SceneLoading;
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
        private readonly SceneLoader _sceneLoader;
        private Wallet _levelWallet;

        public CollisionHandler(Ball ball, IScaler ballScaler, Wallet wallet, PopUpShower popUpShower, SceneLoader sceneLoader)
        {
            _ball = ball;
            _ballScaler = ballScaler;
            _wallet = wallet;
            _popUpShower = popUpShower;
            _sceneLoader = sceneLoader;
            

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
            if (_ball.Level == _ball.MaxLevel)
            {
                _wallet.AddCoins(_levelWallet.Coins);
                _wallet.SaveCurrencies();
                _levelWallet = new Wallet(0);
                _popUpShower.ShowPopUp(PopUpType.Finish);
                var nextSceneNum = Int32.Parse(_sceneLoader.CurrentScene) + 1;
                
                if(nextSceneNum > SaveLoadSystem.LoadUnlockedLevelsCount())
                    SaveLoadSystem.SaveUnlockedLevelsCount(nextSceneNum);
            }
            else
            {
                _levelWallet = new Wallet(0);
                _popUpShower.ShowPopUp(PopUpType.Lose);
            }

            _ball.StopMovement();
            OnFinished?.Invoke();
        }
    }
}
