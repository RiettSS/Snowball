using UI.Popup;

namespace Model
{
    public class Finish
    {
        private readonly CollisionHandler _collisionHandler;
        private readonly ScoreSystem _scoreSystem; 
        private readonly PopUpShower _popUpShower;
        
        public Finish(CollisionHandler collisionHandler, ScoreSystem scoreSystem, PopUpShower popUpShower)
        {
            _collisionHandler = collisionHandler;
            _scoreSystem = scoreSystem;
            _popUpShower = popUpShower;
        }

        public void Collide()
        {
            _collisionHandler.Handle(this);
            _popUpShower.ShowPopUp(PopUpType.Finish);
        }
    }
    
}
