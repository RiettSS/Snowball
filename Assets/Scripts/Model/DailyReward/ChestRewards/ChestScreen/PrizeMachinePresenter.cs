using System;
using Zenject;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class PrizeMachinePresenter : IInitializable, IDisposable
    {
        private PrizeMachine _machine;
        private PrizeMachineView _view;

        public PrizeMachinePresenter(PrizeMachine machine, PrizeMachineView view)
        {
            _machine = machine;
            _view = view;
        }
        
        public void Initialize()
        {
            _machine.OnShow += _view.Show;
            _machine.OnHide += _view.Hide;
        }

        public void Dispose()
        {
            _machine.OnShow -= _view.Show;
            _machine.OnHide -= _view.Hide;
        }
    }
}