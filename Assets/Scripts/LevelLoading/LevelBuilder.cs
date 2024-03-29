﻿using System.Linq;
using Model;
using SceneLoading;
using Sound;
using TMPro;
using UnityEngine;
using View;
using Zenject;

namespace LevelLoading
{
    public class LevelBuilder
    {
        private CollisionHandler _collisionHandler;
        private LevelLoader _levelLoader;
        private ScoreSystem _scoreSystem;
        private SoundSystem _soundSystem;
        private Ball _ball;
        private IScaler _scaler;
        private Transform _uiIndicatorObstaclesTransform;
        private Level _level;
        private readonly SignalBus _signalBus;

        public LevelBuilder(CollisionHandler collisionHandler, LevelLoader levelLoader, ScoreSystem scoreSystem, SoundSystem soundSystem, Ball ball, IScaler scaler, Transform uiTransformTransform, SignalBus signalBus)
        {
            _collisionHandler = collisionHandler;
            _levelLoader = levelLoader;
            _scoreSystem = scoreSystem;
            _soundSystem = soundSystem;
            _ball = ball;
            _scaler = scaler;
            _uiIndicatorObstaclesTransform = uiTransformTransform;
            _signalBus = signalBus;
            
            Debug.Log("current level: " + _levelLoader.CurrentLevel);
            LoadLevel(_levelLoader.CurrentLevel);
        }

        public void LoadLevel(string levelName)
        {
            _level = SaveLoadSystem.LoadLevel(levelName);

            var runtimeBuilder = new RuntimeLevelLoader(_collisionHandler, _scoreSystem, _signalBus, _soundSystem);
            var coinsParent = new GameObject("Coins");
            foreach (var coin in _level.Coins)
            {
                runtimeBuilder.SpawnCoin(coin, coinsParent);
            }

            var obstaclesParent = new GameObject("Obstacles");
            foreach (var obstacle in _level.Obstacles)
            {
                runtimeBuilder.SpawnObstacle(obstacle, obstaclesParent);
            }
            
            var roadsParent = new GameObject("Roads");
            foreach (var road in _level.Roads)
            {
                runtimeBuilder.SpawnRoad(road, roadsParent);
            }
        
            runtimeBuilder.SpawnFinish(_level.Finish);
            runtimeBuilder.SpawnFinishBarrier(_level.FinishBarrier);

            var ballLevel = new Model.Level(0, _level.MaxLevel);
            _ball.ChangeLevel(ballLevel);
            _scaler.ChangePoints(_level.PointsPerLevel);
            
            SpawnUIObstacles();
            
            Debug.Log("Level " + levelName + " loaded successfully");
        }

        private void SpawnUIObstacles()
        {
            var obstacleTypes = _level.ObstacleTypesOnLevel;

            foreach (var obstacleType in obstacleTypes)
            {
                var gameObject = GameObject.Instantiate(IndicatorPrefabDictionary.GetPrefab(obstacleType), _uiIndicatorObstaclesTransform);
                gameObject.layer = 5;
                var view = gameObject.GetComponent<ObstacleView>();
                view.Level = _level.Obstacles.First(x => x.Type == obstacleType).Level; 
                var nestedGameObjects = gameObject.GetComponentsInChildren<Transform>();
                foreach (var nestedObject in nestedGameObjects)
                {
                    nestedObject.gameObject.layer = 5;
                }
                
                gameObject.tag = "UIObstacle";
            }
        }
    }
}