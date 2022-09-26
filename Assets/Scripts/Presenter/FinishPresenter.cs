using System;
using Model;
using View;
using Zenject;

namespace Presenter
{
    public class FinishPresenter : IInitializable, IDisposable
    {
        private Finish _finish;
        private FinishView _finishView;

        public FinishPresenter(Finish finish, FinishView finishView)
        {
            _finish = finish;
            _finishView = finishView;
        }

        public void Initialize()
        {
            _finishView.OnCollisionDetected += _finish.Collide;
        }

        public void Dispose()
        {
            _finishView.OnCollisionDetected -= _finish.Collide;
        }
    }
}
