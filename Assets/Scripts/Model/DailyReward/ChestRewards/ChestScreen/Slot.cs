using System;
using System.Threading;
using UI;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class Slot
    {
        public event Action Opened;
        public event Action<Slot> Clicked;

        public int CurrencyAmount => _currency.Value;
        public readonly CurrencyType Type;
        
        private Currency _currency;

        public Slot(Currency currency, CurrencyType rype)
        {
            _currency = currency;
            Type = rype;
        }

        public void OnClick()
        {
            Clicked?.Invoke(this);
        }

        public void Open()
        {
            Opened?.Invoke();
        }
    }
}