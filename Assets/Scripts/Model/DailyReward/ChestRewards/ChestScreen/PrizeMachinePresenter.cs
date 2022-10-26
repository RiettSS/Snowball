using System;
using Unity.VisualScripting.FullSerializer.Internal.Converters;
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
            _machine.OnWin += _view.Win;
            _machine.OnLose += _view.Lose;
            _machine.SlotOpen += _view.OnSlotOpen;
        }

        public void Dispose()
        {
            _machine.OnShow -= _view.Show;
            _machine.OnHide -= _view.Hide;
            _machine.OnWin -= _view.Win;
            _machine.OnLose -= _view.Lose;
            _machine.SlotOpen -= _view.OnSlotOpen;
        }
    }
}