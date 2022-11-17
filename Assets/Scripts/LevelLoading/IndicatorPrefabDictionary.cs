using System.Collections.Generic;
using UnityEngine;

namespace LevelLoading
{
    public static class IndicatorPrefabDictionary
    {
        private static readonly GameObject _bush = Resources.Load("Prefabs/Environment/Obstacles/Bush/BushIndicator") as GameObject;
        private static readonly GameObject _gift = Resources.Load("Prefabs/Environment/Obstacles/Giftbox/GiftboxIndicator") as GameObject;
        private static readonly GameObject _snowman = Resources.Load("Prefabs/Environment/Obstacles/Snowman/SnowmanIndicator") as GameObject;
        private static readonly GameObject _tent = Resources.Load("Prefabs/Environment/Obstacles/Tent/TentIndicator") as GameObject;
        private static readonly GameObject _tree = Resources.Load("Prefabs/Environment/Obstacles/Tree/TreeIndicator") as GameObject;
        private static readonly GameObject _house = Resources.Load("Prefabs/Environment/Obstacles/House/HouseIndicator") as GameObject;
        private static readonly GameObject _fire = Resources.Load("Prefabs/Environment/Obstacles/Fire/FireIndicator") as GameObject;
        private static readonly GameObject _candy = Resources.Load("Prefabs/Environment/Obstacles/Candy/CandyIndicator") as GameObject;
        private static readonly GameObject _blueSpike = Resources.Load("Prefabs/Environment/UnbreakableObstacles/Spike") as GameObject;

        
        private static readonly Dictionary<SavableObjectType, GameObject> Dictionary =
            new ()
            {
                {SavableObjectType.Gift, _gift},
                {SavableObjectType.Snowman, _snowman},
                {SavableObjectType.Tent, _tent},
                {SavableObjectType.Tree, _tree},
                {SavableObjectType.House, _house},
                {SavableObjectType.Fire, _fire},
                {SavableObjectType.Candy, _candy},
                {SavableObjectType.BlueSpike, _blueSpike},
                {SavableObjectType.Bush, _bush},
            };

        public static GameObject GetPrefab(SavableObjectType type)
        {
            return Dictionary[type];
        }
    }
}