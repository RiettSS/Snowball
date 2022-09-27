using System.IO;

namespace Model
{
    public class Wallet
    {
        public int Coins => _coins.Value;
        
        private CoinsAmount _coins;
        private const string FileName = "coins.txt";

        public Wallet()
        {
            _coins = new CoinsAmount(0);

            if (!File.Exists(FileName))
            {
                File.Create(FileName);
                File.WriteAllText(FileName, "0");
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
            File.WriteAllText(FileName, _coins.Value.ToString());
        }

        public void LoadCoins()
        {
            var content = File.ReadAllText(FileName);
            int.TryParse(content, out var coins);
            _coins = new CoinsAmount(coins);
        }
    }
}
