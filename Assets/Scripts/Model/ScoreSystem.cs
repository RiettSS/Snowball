using System;

namespace Model
{
    public class ScoreSystem
    {
        public event Action<int> OnScoreUpdated;
        public int Score { get; private set; }

        public void AddScore(int amount)
        {
            Score += amount;
            OnScoreUpdated?.Invoke(Score);
        }
    }
}
