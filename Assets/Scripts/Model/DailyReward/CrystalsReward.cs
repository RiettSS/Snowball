using System;

namespace Model.DailyReward
{
    public class CrystalsReward : Reward
    {
        private readonly Currency _currency;
        private readonly Wallet _wallet;

        public CrystalsReward(Currency currency, Wallet wallet)
        {
            _currency = currency;
            _wallet = wallet;
        }
        
        public override void Apply()
        {
            _wallet.AddCrystals(_currency.Value);
            _wallet.SaveCurrencies();
            base.Apply();
        }
    }
}