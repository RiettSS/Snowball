namespace Model.DailyReward.CoinsReward
{
    public class CoinsReward : Reward
    {
        private Wallet _wallet;
        private Currency _currency;

        public CoinsReward(Currency currency, Wallet wallet)
        {
            _wallet = wallet;
            _currency = currency;
        }
        
        public override void Apply()
        {
            _wallet.AddCoins(_currency.Value);
            _wallet.SaveCurrencies();
            base.Apply();
        }
    }
}
