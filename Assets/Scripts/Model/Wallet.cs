using System.IO;
using UnityEngine;

namespace Model
{
    public class Wallet
    {
        public int Coins => _coins.Value;
        
        private CoinsAmount _coins;
        private readonly string _fileName;

        public Wallet()
        {
            _coins = new CoinsAmount(0);

            _fileName = Application.persistentDataPath + "/coins.txt";
            
            if (!File.Exists(_fileName))
            {
                File.Create(_fileName);
                File.WriteAllText(_fileName, "0");
            }
            else
            {
                LoadCoins();
            }
            
        }
        
        public Wallet(int coins)
        {
            _coins = new CoinsAmount(coins);
        }

        public void AddCoins(int amount)
        {
            _coins = _coins.AddCoins(amount);
        }

        public void ReduceCoins(int amount)
        {
            _coins = _coins.ReduceCoins(amount);
        }

        public void SaveCoins()
        {
            File.WriteAllText(_fileName, _coins.Value.ToString());
        }

        public void LoadCoins()
        {
            var content = File.ReadAllText(_fileName);
            int.TryParse(content, out var coins);
            _coins = new CoinsAmount(coins);
        }
    }
}
