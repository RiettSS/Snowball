using System.Numerics;

namespace LevelLoading
{
    public interface ILoadableView
    {
        void SetTransform(Vector3 position, Vector3 rotation);
    }
}