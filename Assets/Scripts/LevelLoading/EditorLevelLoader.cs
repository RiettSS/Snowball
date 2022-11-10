using UnityEngine;
using View;

namespace LevelLoading
{
    public class EditorLevelLoader
    {
        public void SpawnObstacle(ObstacleDTO obstacleDto, GameObject parent)
        {
            var prefab = PrefabDictionary.GetPrefab(obstacleDto.Type);

            UnityEngine.Vector3 position =
                new UnityEngine.Vector3(obstacleDto.Position.X, obstacleDto.Position.Y, obstacleDto.Position.Z);
            
            var quaternion = new Quaternion(obstacleDto.Rotation.X, obstacleDto.Rotation.Y, obstacleDto.Rotation.Z, obstacleDto.RotationW);
            var obstacle = GameObject.Instantiate(prefab, position, quaternion, null);
            obstacle.transform.parent = parent.transform;

            var obstacleView = obstacle.GetComponent<ObstacleView>();
            obstacleView.ScorePerObstacle = obstacleDto.Score;
            
        }

        public void SpawnCoin(CoinDTO coinDto, GameObject parent)
        {
            var prefab = PrefabDictionary.GetPrefab(coinDto.Type);

            UnityEngine.Vector3 position =
                new UnityEngine.Vector3(coinDto.Position.X, coinDto.Position.Y, coinDto.Position.Z);
            
            var quaternion = new Quaternion(coinDto.Rotation.X, coinDto.Rotation.Y, coinDto.Rotation.Z, coinDto.RotationW);
            var coin = GameObject.Instantiate(prefab, position, quaternion, null);
            coin.transform.parent = parent.transform;

            var coinView = coin.GetComponent<CoinView>();
            coinView.Cost = coinDto.Cost;
        }
    }
}