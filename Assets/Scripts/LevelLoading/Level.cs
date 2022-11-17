using System;
using System.Collections.Generic;

namespace LevelLoading
{
    [Serializable]
    public struct Level
    {
        public readonly List<ObstacleDTO> Obstacles;
        public readonly List<CoinDTO> Coins;
        public readonly List<TransformDTO> Roads;
        public readonly TransformDTO Finish;
        public readonly TransformDTO FinishBarrier;
        public readonly int PointsPerLevel;
        public readonly int MaxLevel;
        public readonly List<SavableObjectType> ObstacleTypesOnLevel;

        public Level(List<ObstacleDTO> obstacles, List<CoinDTO> coins, List<TransformDTO> roads, TransformDTO finish, TransformDTO finishBarrier, int pointsPerLevel, int maxLevel, List<SavableObjectType> obstacleTypesOnLevel)
        {
            Obstacles = obstacles;
            Coins = coins;
            Roads = roads;
            Finish = finish;
            FinishBarrier = finishBarrier;
            PointsPerLevel = pointsPerLevel;
            MaxLevel = maxLevel;
            ObstacleTypesOnLevel = obstacleTypesOnLevel;
        }
    }
}