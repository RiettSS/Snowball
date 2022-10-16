using System;
using TMPro;
using Zenject;

namespace Store
{
    public class StoreSlotPresenter : IInitializable, IDisposable
    {
        private StoreSlot _storeSlot;
        private StoreSlotView _view;

        public StoreSlotPresenter(StoreSlot storeSlot, StoreSlotView storeSlotView)
        {
            _storeSlot = storeSlot;
            _view = storeSlotView;
        }
        
        public void Initialize()
        {
            _view.BuyButtonPressed += _storeSlot.OnBuyPressed;
            _view.EquipButtonPressed += _storeSlot.OnEquipPressed;
            _storeSlot.StateChanged += _view.ChangeState;
        }

        public void Dispose()
        {
            _view.BuyButtonPressed -= _storeSlot.OnBuyPressed;
            _view.EquipButtonPressed -= _storeSlot.OnEquipPressed;
            _storeSlot.StateChanged -= _view.ChangeState;
        }
    }
}