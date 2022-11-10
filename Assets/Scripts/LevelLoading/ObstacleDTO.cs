using System;

namespace LevelLoading
{
    [Serializable]
    public struct ObstacleDTO
    {
        public readonly Vector3 Position;
        public readonly Vector3 Rotation;
        public readonly float RotationW;
        public readonly SavableObjectType Type;
        public readonly int Score;
        public readonly int Level;

        public ObstacleDTO(Vector3 position, Vector3 rotation, float rotationW, SavableObjectType type, int score, int level)
        {
            Position = position;
            Rotation = rotation;
            RotationW = rotationW;
            Type = type;
            Score = score;
            Level = level;
        }
    }
}