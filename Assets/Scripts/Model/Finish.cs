namespace Model
{
    public class Finish
    {
        private readonly CollisionHandler _collisionHandler;
        private readonly ScoreSystem _scoreSystem;

        public Finish(CollisionHandler collisionHandler, ScoreSystem scoreSystem)
        {
            _collisionHandler = collisionHandler;
            _scoreSystem = scoreSystem;
        }

        public void Collide()
        {
            _collisionHandler.Handle(this);
        }
    }
    
}
