using System;

namespace LevelLoading
{
    [Serializable]
    public struct ObstacleDTO
    {
        public readonly Vector3 Position;
        public readonly Vector4 Rotation;
        public readonly Vector3 Scale;
        public readonly SavableObjectType Type;
        public readonly int Score;
        public readonly int Level;

        public ObstacleDTO(Vector3 position, Vector4 rotation, Vector3 scale, SavableObjectType type, int score,
            int level)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
            Type = type;
            Score = score;
            Level = level;
        }
    }
}