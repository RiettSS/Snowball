using System;
using Model.BallModel;
using Zenject;

namespace Model
{
    public class LevelIndicator: IInitializable, IDisposable
    {
        public event Action<int> LevelPointsLeftUpdated;
        public event Action<int> LevelUpdated;
        
        private IScaler _scaler;

        public LevelIndicator(IScaler scaler)
        {
            _scaler = scaler;
        }

        public void Initialize()
        {
            _scaler.LevelPointsUpdated += OnLevelPointsUpdated;
            _scaler.LevelUpdated += OnLevelUpdated;
        }

        public void Dispose()
        {
            _scaler.LevelPointsUpdated -= OnLevelPointsUpdated;
            _scaler.LevelUpdated -= OnLevelUpdated;
        }
        
        private void OnLevelPointsUpdated(int points)
        {
            var pointsLeft = _scaler.MaxPoints - points;
            LevelPointsLeftUpdated?.Invoke(pointsLeft);
        }

        private void OnLevelUpdated(int level)
        {
            LevelUpdated?.Invoke(level);
        }
    }
}
