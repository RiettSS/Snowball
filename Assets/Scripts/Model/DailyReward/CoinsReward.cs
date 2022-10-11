using System;
using System.Diagnostics.Tracing;

namespace Model.DailyReward
{
    public class CoinsReward : IReward
    {
        public event Action Activated;
        public event Action Deactivated;
        public event Action Today;

        public event Action Applied;

        private readonly CoinsAmount _coinsAmount;
        private readonly Wallet _wallet;

        public CoinsReward(CoinsAmount coinsAmount, Wallet wallet)
        {
            _coinsAmount = coinsAmount;
            _wallet = wallet;
        }
        
        public void Apply()
        {
            _wallet.AddCoins(_coinsAmount.Value);
            Applied?.Invoke();
        }

        public void SetActive()
        {
            Activated?.Invoke();
        }

        public void SetInactive()
        {
            Deactivated?.Invoke();
        }
    }
}
