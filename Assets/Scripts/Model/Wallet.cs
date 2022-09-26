namespace Model
{
    public class Wallet
    {
        private CoinsAmount _coins;

        public Wallet()
        {
            _coins = new CoinsAmount(0);
        }
        
        public Wallet(int coins)
        {
            _coins = new CoinsAmount(coins);
        }
    }
}
