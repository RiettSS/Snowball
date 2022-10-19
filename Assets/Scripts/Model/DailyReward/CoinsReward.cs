﻿using System;
using System.Diagnostics.Tracing;

namespace Model.DailyReward
{
    public class CoinsReward : IReward
    {
        public event Action Activated;
        public event Action Deactivated;
        public event Action Today;
        public event Action Applied;
        public event Action<int> AppliedOnDay;

        public int Day { get; set; }

        private readonly Currency _currency;
        private readonly Wallet _wallet;

        public CoinsReward(Currency currency, Wallet wallet)
        {
            _currency = currency;
            _wallet = wallet;
        }
        
        public void Apply()
        {
            _wallet.AddCoins(_currency.Value);
            _wallet.SaveCurrencies();
            Applied?.Invoke();
            AppliedOnDay?.Invoke(Day);
        }

        public void SetActive()
        {
            Activated?.Invoke();
        }

        public void SetInactive()
        {
            Deactivated?.Invoke();
        }

        public void SetTodayBackground()
        {
            Today?.Invoke();
        }
    }
}
