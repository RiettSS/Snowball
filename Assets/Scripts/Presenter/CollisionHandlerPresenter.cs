using Model;

namespace Presenter
{
    public sealed class CollisionHandlerPresenter
    {
        private readonly CollisionHandler _handler;

        public CollisionHandlerPresenter(CollisionHandler handler)
        {
            _handler = handler;
        }

        public void Handle(Obstacle obstacle)
        {
            _handler.Handle(obstacle);
        }

        public void Handle(Coin coin)
        {
            _handler.Handle(coin);
        }
    }
}
