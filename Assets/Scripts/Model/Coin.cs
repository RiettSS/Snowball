using System;

namespace Model
{
    public class Coin
    {
        public event Action OnRelease;
        
        public readonly int Cost;

        private CollisionHandler _collisionHandler;
        
        public Coin(int cost, CollisionHandler collisionHandler)
        {
            Cost = cost;
            _collisionHandler = collisionHandler;
        }

        public void Collide()
        {
            _collisionHandler.Handle(this);
        }

        public void Release()
        {
            OnRelease?.Invoke();
        }
    }
}
