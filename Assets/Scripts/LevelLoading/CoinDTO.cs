using System;

namespace LevelLoading
{
    [Serializable]
    public struct CoinDTO
    {
        public readonly Vector3 Position;
        public readonly Vector4 Rotation;
        public readonly int Cost;
        public readonly SavableObjectType Type;

        public CoinDTO(Vector3 position, Vector4 rotation, int cost, SavableObjectType type)
        {
            Position = position;
            Rotation = rotation;
            Cost = cost;
            Type = type;
        }
    }
}