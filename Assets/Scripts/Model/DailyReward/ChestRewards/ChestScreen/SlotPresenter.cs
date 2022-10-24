using System;
using Zenject;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class SlotPresenter : IInitializable, IDisposable
    {
        private Slot _slot;
        private SlotView _view;

        public SlotPresenter(Slot slot, SlotView view)
        {
            _slot = slot;
            _view = view;
        }
        
        public void Initialize()
        {
            _view.Click += _slot.OnClick;
            _slot.Opened += _view.Unlock;
            
            _view.SetCurrencyAmount(_slot.CurrencyAmount);
            _view.Lock();
        }

        public void Dispose()
        {
            _view.Click -= _slot.OnClick;
            _slot.Opened -= _view.Unlock;
        }
    }
}