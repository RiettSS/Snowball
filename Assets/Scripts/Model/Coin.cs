namespace Model
{
    public class Coin
    {
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
    }
}
