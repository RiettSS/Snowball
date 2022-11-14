using System;
using System.Collections.Generic;

namespace LevelLoading
{
    [Serializable]
    public struct Level
    {
        public readonly List<ObstacleDTO> Obstacles;
        public readonly List<CoinDTO> Coins;
        public readonly List<PositionDTO> Roads;
        public readonly PositionDTO Finish;
        public readonly int PointsPerLevel;
        public readonly int MaxLevel;
        public readonly List<SavableObjectType> ObstacleTypesOnLevel;

        public Level(List<ObstacleDTO> obstacles, List<CoinDTO> coins, List<PositionDTO> roads, PositionDTO finish, int pointsPerLevel, int maxLevel, List<SavableObjectType> obstacleTypesOnLevel)
        {
            Obstacles = obstacles;
            Coins = coins;
            Roads = roads;
            Finish = finish;
            PointsPerLevel = pointsPerLevel;
            MaxLevel = maxLevel;
            ObstacleTypesOnLevel = obstacleTypesOnLevel;
        }
    }
}