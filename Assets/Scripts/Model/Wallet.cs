using System;

namespace Model
{
    public class Wallet
    {
        public event Action<int> CoinsAmountChanged;
        public event Action<int> CoinsAmountAdded;
        
        public int Coins => _coins.Value;
        private CoinsAmount _coins;

        public Wallet()
        {
            _coins = SaveLoadSystem.LoadCoins();
        }

        public Wallet(int coins)
        {
            _coins = new CoinsAmount(coins);
        }

        public void AddCoins(int amount)
        {
            _coins = _coins.AddCoins(amount);
            CoinsAmountChanged?.Invoke(Coins);
            CoinsAmountAdded?.Invoke(amount);
        }

        public void ReduceCoins(int amount)
        {
            _coins = _coins.ReduceCoins(amount);
            CoinsAmountChanged?.Invoke(Coins);
        }

        public void SaveCoins()
        {
            SaveLoadSystem.SaveCoins(_coins);
        }
    }
}
