﻿using System;

namespace LevelLoading
{
    [Serializable]
    public struct Vector3
    {
        public readonly float x;
        public readonly float y;
        public readonly float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}