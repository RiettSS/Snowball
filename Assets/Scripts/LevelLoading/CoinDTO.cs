using System;

namespace LevelLoading
{
    [Serializable]
    public struct CoinDTO
    {
        public readonly Vector3 Position;
        public readonly Vector3 Rotation;
        public readonly float RotationW;
        public readonly int Cost;
        public readonly SavableObjectType Type;

        public CoinDTO(Vector3 position, Vector3 rotation, float rotationW, int cost, SavableObjectType type)
        {
            Position = position;
            Rotation = rotation;
            RotationW = rotationW;
            Cost = cost;
            Type = type;
        }
    }
}