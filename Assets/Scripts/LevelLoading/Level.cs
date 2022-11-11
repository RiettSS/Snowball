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

        public Level(List<ObstacleDTO> obstacles, List<CoinDTO> coins, List<PositionDTO> roads, PositionDTO finish)
        {
            Obstacles = obstacles;
            Coins = coins;
            Roads = roads;
            Finish = finish;
        }
    }
}