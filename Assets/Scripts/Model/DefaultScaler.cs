using System;
using Firebase.Analytics;
using UnityEngine.SceneManagement;

namespace Model
{
    public class DefaultScaler : IScaler
    {
        public event Action<int> LevelPointsUpdated;
        public event Action<int> LevelUpdated;

        public int MaxPoints => _maxPoints;
        
        private readonly Ball _ball;
        private readonly ScoreSystem _scoreSystem;
        private readonly int _maxPoints;
        private int _levelPoints;

        public DefaultScaler(Ball ball, ScoreSystem scoreSystem, int pointsPerLevel)
        {
            _ball = ball;
            _scoreSystem = scoreSystem;
            _maxPoints = pointsPerLevel;
        }
        
        public void Handle(Obstacle obstacle)
        {
            if (obstacle.Level > _ball.Level)
            {
                _ball.StopMovement();
                _ball.Smash();
                
                FirebaseAnalytics.LogEvent("level_defeat_by_obstacle",
                    new Parameter(FirebaseAnalytics.ParameterLevelName, SceneManager.GetActiveScene().name),
                    new Parameter("ball_level", _ball.Level));
            }
            else if (obstacle.Level == _ball.Level)
            {
                AddPoint();
                TryGrow();
                _scoreSystem.AddScore(obstacle.Score);
            }
            else
            {
                _scoreSystem.AddScore(obstacle.Score);
            }
        }

        private void AddPoint()
        {
            _levelPoints++;
            LevelPointsUpdated?.Invoke(_levelPoints);
        }

        private void TryGrow()
        {
            if (_levelPoints < _maxPoints)
                return;
            
            _ball.Upgrade();
            LevelUpdated?.Invoke(_ball.Level);
            _levelPoints = 0;
            LevelPointsUpdated?.Invoke(_levelPoints);
        }
    }
}
