using Model;
using SceneLoading;
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
        private Transform _uiIndicatorObstaclesTransform;
        private LevelLoading.Level _level;

        public LevelBuilder(CollisionHandler collisionHandler, LevelLoader levelLoader, ScoreSystem scoreSystem, Ball ball, IScaler scaler, Transform uiTransformTransform)
        {
            _collisionHandler = collisionHandler;
            _levelLoader = levelLoader;
            _scoreSystem = scoreSystem;
            _ball = ball;
            _scaler = scaler;
            _uiIndicatorObstaclesTransform = uiTransformTransform;
            
            Debug.Log("current level: " + _levelLoader.CurrentLevel);
            LoadLevel(_levelLoader.CurrentLevel);
        }

        public void LoadLevel(string levelName)
        {
            _level = SaveLoadSystem.LoadLevel(levelName);

            var runtimeBuilder = new RuntimeLevelLoader(_collisionHandler, _scoreSystem);
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
                var gameObject = GameObject.Instantiate(PrefabDictionary.GetPrefab(obstacleType), _uiIndicatorObstaclesTransform);
                gameObject.layer = 5;
                var nestedGameObjects = gameObject.GetComponentsInChildren<Transform>();
                foreach (var nestedObject in nestedGameObjects)
                {
                    nestedObject.gameObject.layer = 5;
                }
                
                gameObject.tag = "UIObstacle";
                gameObject.transform.localScale *= 25;
            }
        }
    }
}