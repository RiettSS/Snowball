using System.Collections.Generic;
using UnityEngine;

namespace LevelLoading
{
    public static class PrefabDictionary
    {
        private static readonly GameObject _coin = Resources.Load("Prefabs/Environment/Coin") as GameObject;
        private static readonly GameObject _bush = Resources.Load("Prefabs/Environment/Obstacles/Bush/Bush") as GameObject;
        private static readonly GameObject _gift = Resources.Load("Prefabs/Environment/Obstacles/Giftbox/Giftbox") as GameObject;
        private static readonly GameObject _snowman = Resources.Load("Prefabs/Environment/Obstacles/Snowman/Snowman") as GameObject;
        private static readonly GameObject _tent = Resources.Load("Prefabs/Environment/Obstacles/Tent/Tent") as GameObject;
        private static readonly GameObject _tree = Resources.Load("Prefabs/Environment/Obstacles/Tree/Tree") as GameObject;
        private static readonly GameObject _house = Resources.Load("Prefabs/Environment/Obstacles/House/House") as GameObject;
        private static readonly GameObject _fire = Resources.Load("Prefabs/Environment/Obstacles/Fire/Fire") as GameObject;
        private static readonly GameObject _candy = Resources.Load("Prefabs/Environment/Obstacles/Candy/Candy") as GameObject;
        private static readonly GameObject _blueSpike = Resources.Load("Prefabs/Environment/UnbreakableObstacles/Spike") as GameObject;
        private static readonly GameObject _snowRoad = Resources.Load("Prefabs/Environment/Snowroad") as GameObject;
        private static readonly GameObject _finish = Resources.Load("Prefabs/Finish/Finish") as GameObject;
        
        private static readonly Dictionary<SavableObjectType, GameObject> Dictionary =
            new ()
            {
                {SavableObjectType.Coin, _coin},
                {SavableObjectType.Gift, _gift},
                {SavableObjectType.Snowman, _snowman},
                {SavableObjectType.Tent, _tent},
                {SavableObjectType.Tree, _tree},
                {SavableObjectType.House, _house},
                {SavableObjectType.Fire, _fire},
                {SavableObjectType.Candy, _candy},
                {SavableObjectType.BlueSpike, _blueSpike},
                {SavableObjectType.Bush, _bush},
                {SavableObjectType.SnowRoad, _snowRoad},
                {SavableObjectType.Finish, _finish},
            };

        public static GameObject GetPrefab(SavableObjectType type)
        {
            return Dictionary[type];
        }
    }
}