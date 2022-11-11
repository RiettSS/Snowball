using System;

namespace LevelLoading
{
    [Serializable]
    public struct PositionDTO
    {
        public readonly Vector3 Position;
        public readonly Vector4 Rotation;

        public PositionDTO(Vector3 position, Vector4 rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}