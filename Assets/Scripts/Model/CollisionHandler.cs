﻿using System;
using Firebase.Analytics;
using SceneLoading;
using UI.Popup;
using UnityEngine.SceneManagement;
using Vibration;

namespace Model
{
    public sealed class CollisionHandler
    {
        public event Action OnFinished;

        private readonly Ball _ball;
        private readonly IScaler _ballScaler;
        private readonly PopUpShower _popUpShower;
        private readonly Wallet _wallet;
        private readonly LevelLoader _levelLoader;
        private readonly ScoreSystem _scoreSystem;
        private Wallet _levelWallet;

        public CollisionHandler(Ball ball, IScaler ballScaler, Wallet wallet, PopUpShower popUpShower, LevelLoader levelLoader, ScoreSystem scoreSystem)
        {
            _ball = ball;
            _ballScaler = ballScaler;
            _wallet = wallet;
            _popUpShower = popUpShower;
            _levelLoader = levelLoader;
            _scoreSystem = scoreSystem;
            

            _levelWallet = new Wallet(0);
        }
        
        public void Handle(Obstacle obstacle)
        {
            if (obstacle.Level <= _ball.Level)
            {
                obstacle.Smash();
                Vibrator.Vibrate();
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
                var nextSceneNum = Int32.Parse(_levelLoader.CurrentLevel) + 1;


                if (SceneManager.GetActiveScene().name == "LevelScreen")
                {
                    FirebaseAnalytics.LogEvent("level_success",
                        new Parameter(FirebaseAnalytics.ParameterLevelName, _levelLoader.CurrentLevel),
                        new Parameter(FirebaseAnalytics.ParameterScore, _scoreSystem.Score));
                }
                else
                {
                    FirebaseAnalytics.LogEvent("level_success",
                        new Parameter(FirebaseAnalytics.ParameterLevelName, SceneManager.GetActiveScene().name),
                        new Parameter(FirebaseAnalytics.ParameterScore, _scoreSystem.Score));
                }

                if(nextSceneNum > SaveLoadSystem.LoadUnlockedLevelsCount())
                    SaveLoadSystem.SaveUnlockedLevelsCount(nextSceneNum);
            }
            else
            {
                _levelWallet = new Wallet(0);
                _popUpShower.ShowPopUp(PopUpType.LoseByLowLevelOnFinish);
                
                FirebaseAnalytics.LogEvent("level_defeat_on_finish",
                    new Parameter(FirebaseAnalytics.ParameterLevelName, SceneManager.GetActiveScene().name),
                    new Parameter("ball_level", _ball.Level));
            }

            _ball.StopMovement();
            OnFinished?.Invoke();
        }
    }
}
