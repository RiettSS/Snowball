using Model;
using SceneLoading;
using TMPro;
using UnityEngine;

namespace LevelLoading
{
    public class LevelBuilder
    {
        private CollisionHandler _collisionHandler;
        private LevelLoader _levelLoader;
        private ScoreSystem _scoreSystem;
        private Ball _ball;
        private IScaler _scaler;

        public LevelBuilder(CollisionHandler collisionHandler, LevelLoader levelLoader, ScoreSystem scoreSystem, Ball ball, IScaler scaler)
        {
            _collisionHandler = collisionHandler;
            _levelLoader = levelLoader;
            _scoreSystem = scoreSystem;
            _ball = ball;
            _scaler = scaler;
            
            LoadLevel(_levelLoader.CurrentLevel);
        }

        public void LoadLevel(string levelName)
        {
            var level = SaveLoadSystem.LoadLevel(levelName);

            var runtimeBuilder = new RuntimeLevelLoader(_collisionHandler, _scoreSystem);
            var coinsParent = new GameObject("Coins");
            foreach (var coin in level.Coins)
            {
                runtimeBuilder.SpawnCoin(coin, coinsParent);
            }

            var obstaclesParent = new GameObject("Obstacles");
            foreach (var obstacle in level.Obstacles)
            {
                runtimeBuilder.SpawnObstacle(obstacle, obstaclesParent);
            }
            
            var roadsParent = new GameObject("Roads");
            foreach (var road in level.Roads)
            {
                runtimeBuilder.SpawnRoad(road, roadsParent);
            }
        
            runtimeBuilder.SpawnFinish(level.Finish);

            var ballLevel = new Model.Level(0, level.MaxLevel);
            _ball.ChangeLevel(ballLevel);
            
            _scaler.ChangePoints(level.PointsPerLevel);
            
            Debug.Log("Level " + levelName + " loaded successfully");
        }
    }
}