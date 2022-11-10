using System;
using System.Collections.Generic;

namespace LevelLoading
{
    [Serializable]
    public struct Level
    {
        public readonly List<ObstacleDTO> Obstacles;
        public readonly List<CoinDTO> Coins;

        public Level(List<ObstacleDTO> obstacles, List<CoinDTO> coins)
        {
            Obstacles = obstacles;
            Coins = coins;
        }
    }
}