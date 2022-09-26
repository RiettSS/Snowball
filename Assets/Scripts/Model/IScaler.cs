using System;

namespace Model
{
    public interface IScaler
    {
        event Action<int> LevelPointsUpdated;
        event Action<int> LevelUpdated;

        int MaxPoints { get; }
        
        void Handle(Obstacle obstacle);
    }
}
