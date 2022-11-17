using Model;
using Presenter;
using UnityEngine;
using View;

namespace LevelLoading
{
    public class RuntimeLevelLoader
    {
        private CollisionHandler _collisionHandler;
        private ScoreSystem _scoreSystem;

        public RuntimeLevelLoader(CollisionHandler collisionHandler, ScoreSystem scoreSystem)
        {
            _collisionHandler = collisionHandler;
            _scoreSystem = scoreSystem;
        }

        public void SpawnObstacle(ObstacleDTO obstacleDto, GameObject parent)
        {
            var prefab = PrefabDictionary.GetPrefab(obstacleDto.Type);

            UnityEngine.Vector3 position =
                new UnityEngine.Vector3(obstacleDto.Transform.Position.x, obstacleDto.Transform.Position.y, obstacleDto.Transform.Position.z);
            
            var quaternion = new Quaternion(obstacleDto.Transform.Rotation.x, obstacleDto.Transform.Rotation.y, obstacleDto.Transform.Rotation.z, obstacleDto.Transform.Rotation.w);
            var obstacle = GameObject.Instantiate(prefab, position, quaternion, null);
            obstacle.transform.parent = parent.transform;

            var obstacleView = obstacle.GetComponent<ObstacleView>();
            obstacleView.ScorePerObstacle = obstacleDto.Score;
            obstacleView.Level = obstacleDto.Level;
            obstacleView.gameObject.transform.localScale =
                new UnityEngine.Vector3(obstacleDto.Transform.Scale.x, obstacleDto.Transform.Scale.y, obstacleDto.Transform.Scale.z);

            var obstacleModel = new Obstacle(obstacleView.Level, obstacleView.ScorePerObstacle, _collisionHandler);
            var presenter = new ObstaclePresenter(obstacleModel, obstacleView);
            presenter.Initialize();
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

            var coinModel = new Coin(coinView.Cost, _collisionHandler);
            var presenter = new CoinPresenter(coinModel, coinView);
            presenter.Initialize();
        }

        public void SpawnRoad(TransformDTO transformDto, GameObject parent)
        {
            var prefab = PrefabDictionary.GetPrefab(SavableObjectType.SnowRoad);

            UnityEngine.Vector3 position =
                new UnityEngine.Vector3(transformDto.Position.x, transformDto.Position.y, transformDto.Position.z);
            
            var quaternion = new Quaternion(transformDto.Rotation.x, transformDto.Rotation.y, transformDto.Rotation.z, transformDto.Rotation.w);
            var road = GameObject.Instantiate(prefab, position, quaternion, null);
            road.transform.parent = parent.transform;
        }

        public void SpawnFinish(TransformDTO transformDto)
        {
            var prefab = PrefabDictionary.GetPrefab(SavableObjectType.Finish);

            UnityEngine.Vector3 position =
                new UnityEngine.Vector3(transformDto.Position.x, transformDto.Position.y, transformDto.Position.z);
            
            var quaternion = new Quaternion(transformDto.Rotation.x, transformDto.Rotation.y, transformDto.Rotation.z, transformDto.Rotation.w);
            var finish = GameObject.Instantiate(prefab, position, quaternion, null);
            var finishView = finish.GetComponent<FinishView>();
            var finishModel = new Finish(_collisionHandler, _scoreSystem);
            var presenter = new FinishPresenter(finishModel, finishView);
            presenter.Initialize();
        }
        
        public void SpawnFinishBarrier(TransformDTO transformDto)
        {
            var prefab = PrefabDictionary.GetPrefab(SavableObjectType.FinishBarrier);
            
            UnityEngine.Vector3 position =
                new UnityEngine.Vector3(transformDto.Position.x, transformDto.Position.y, transformDto.Position.z);
            
            var quaternion = new Quaternion(transformDto.Rotation.x, transformDto.Rotation.y, transformDto.Rotation.z, transformDto.Rotation.w);
            var barrier = GameObject.Instantiate(prefab, position, quaternion, null);
        }
    }
}