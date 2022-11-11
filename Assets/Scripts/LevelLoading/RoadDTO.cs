using System;

namespace LevelLoading
{
    [Serializable]
    public struct RoadDTO
    {
        public readonly Vector3 Position;
        public readonly Vector3 Rotation;
        public readonly float RotationW;

        public RoadDTO(Vector3 position, Vector3 rotation, float rotationW)
        {
            Position = position;
            Rotation = rotation;
            RotationW = rotationW;
        }
    }
}