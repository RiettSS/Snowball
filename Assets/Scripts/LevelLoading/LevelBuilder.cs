using Model;
using UnityEngine;

namespace LevelLoading
{
    public class LevelBuilder
    {
        private CollisionHandler _collisionHandler;

        public LevelBuilder(CollisionHandler collisionHandler)
        {
            _collisionHandler = collisionHandler;
            LoadLevel("6");
            Debug.Log("Level Builder Created");
        }

        public void LoadLevel(string levelName)
        {
            var level = SaveLoadSystem.LoadLevel(levelName);

            var editorBuilder = new RuntimeLevelLoader(_collisionHandler);
            var coinsParent = new GameObject("Coins");
            foreach (var coin in level.Coins)
            {
                editorBuilder.SpawnCoin(coin, coinsParent);
            }

            var obstaclesParent = new GameObject("Obstacles");
            foreach (var obstacle in level.Obstacles)
            {
                editorBuilder.SpawnObstacle(obstacle, obstaclesParent);
            }

            Debug.Log("Level " + levelName + " loaded successfully");
        }
    }
}