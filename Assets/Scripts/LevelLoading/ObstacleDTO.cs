using System;

namespace LevelLoading
{
    [Serializable]
    public struct ObstacleDTO
    {
        public readonly TransformDTO Transform;
        public readonly SavableObjectType Type;
        public readonly int Score;
        public readonly int Level;

        public ObstacleDTO(TransformDTO transform, SavableObjectType type, int score, int level)
        {
            Transform = transform;
            Type = type;
            Score = score;
            Level = level;
        }
    }
}