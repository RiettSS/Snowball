using System;

namespace Model
{
    public class Obstacle
    {
        public event Action OnSmash;
        
        public readonly int Level;
        public readonly int Score;

        private CollisionHandler _collisionHandler;
        
        public Obstacle(int level, int score, CollisionHandler collisionHandler)
        {
            Level = level;
            Score = score;
            _collisionHandler = collisionHandler;
        }

        public void Collide()
        {
            _collisionHandler.Handle(this);
        }

        public void Smash()
        {
            OnSmash?.Invoke();
        }
    }
}
