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
            _crystals = SaveLoadSystem.LoadCrystals();
        }

        public Wallet(int coins)
        {
            _coins = new Currency(coins);
            _crystals = new Currency(10);
        }

        public void AddCoins(int amount)
        {
            _coins = _coins.Add(amount);
            CoinsAmountChanged?.Invoke(Coins);
            CoinsAmountAdded?.Invoke(amount);
        }

        public void ReduceCoins(int amount)
        {
            _coins = _coins.Reduce(amount);
            CoinsAmountChanged?.Invoke(Coins);
        }
        
        public void AddCrystals(int amount)
        {
            _crystals = _crystals.Add(amount);
            CrystalsAmountChanged?.Invoke(Crystals);
            CrystalsAmountAdded?.Invoke(amount);
        }

        public void ReduceCrystals(int amount)
        {
            _crystals = _crystals.Reduce(amount);
            CrystalsAmountChanged?.Invoke(Crystals);
        }

        public void SaveCurrencies()
        {
            SaveLoadSystem.SaveCoins(_coins);
            SaveLoadSystem.SaveCrystals(_crystals);
        }
    }
}
