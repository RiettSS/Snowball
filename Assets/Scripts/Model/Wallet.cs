using System;
using UnityEngine;

namespace Model
{
    public class Wallet
    {
        public event Action<int> CoinsAmountChanged;
        public event Action<int> CoinsAmountAdded;
        public event Action<int> CrystalsAmountChanged;
        public event Action<int> CrystalsAmountAdded;
        
        public int Coins => _coins.Value;
        public int Crystals => _crystals.Value;
        private Currency _coins;
        private Currency _crystals;

        public Wallet()
        {
            _coins = SaveLoadSystem.LoadCoins();
        }

        public Wallet(int coins)
        {
            _coins = new Currency(coins);
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
        
        public void AddCrystals(int amount)
        {
            _crystals = _crystals.AddCoins(amount);
            CrystalsAmountChanged?.Invoke(Coins);
            CrystalsAmountAdded?.Invoke(amount);
        }

        public void ReduceCrystals(int amount)
        {
            _crystals = _crystals.ReduceCoins(amount);
            CrystalsAmountChanged?.Invoke(Coins);
        }

        public void SaveCoins()
        {
            SaveLoadSystem.SaveCoins(_coins);
        }
    }
}
