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
                new UnityEngine.Vector3(obstacleDto.Position.x, obstacleDto.Position.y, obstacleDto.Position.z);
            
            var quaternion = new Quaternion(obstacleDto.Rotation.x, obstacleDto.Rotation.y, obstacleDto.Rotation.z, obstacleDto.Rotation.w);
            var obstacle = GameObject.Instantiate(prefab, position, quaternion, null);
            obstacle.transform.parent = parent.transform;

            var obstacleView = obstacle.GetComponent<ObstacleView>();
            obstacleView.ScorePerObstacle = obstacleDto.Score;
            
        }

        public void SpawnCoin(CoinDTO coinDto, GameObject parent)
        {
            var prefab = PrefabDictionary.GetPrefab(coinDto.Type);

            UnityEngine.Vector3 position =
                new UnityEngine.Vector3(coinDto.Position.x, coinDto.Position.y, coinDto.Position.z);
            
            var quaternion = new Quaternion(coinDto.Rotation.x, coinDto.Rotation.y, coinDto.Rotation.z, coinDto.Rotation.w);
            var coin = GameObject.Instantiate(prefab, position, quaternion, null);
            coin.transform.parent = parent.transform;

            var coinView = coin.GetComponent<CoinView>();
            coinView.Cost = coinDto.Cost;
        }
    }
}