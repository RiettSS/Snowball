using System;
using UnityEngine;

namespace LevelLoading
{
    [Serializable]
    public struct TransformDTO
    {
        public readonly Vector3 Position;
        public readonly Vector4 Rotation;
        public readonly Vector3 Scale;

        public TransformDTO(Transform transform)
        {
            var transformPosition = transform.position;
            var position  = new Vector3(transformPosition.x, transformPosition.y,
                transformPosition.z);
            
            var transformRotation = transform.rotation;
            var rotation = new Vector4(transformRotation.x, transformRotation.y,
                transformRotation.z, transformRotation.w);

            var transformLocalScale = transform.localScale;
            var scale = new Vector3(transformLocalScale.x, transformLocalScale.y,
                transformLocalScale.z);

            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }
}