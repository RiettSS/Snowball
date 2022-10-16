using System;

namespace Model
{
    [Serializable]
    public struct Currency
    {
        public readonly int Value;

        private const int MinCoins = 0;

        public Currency(int coinsAmount)
        {
            Value = Math.Clamp(coinsAmount, MinCoins, int.MaxValue);
        }

        public Currency AddCoins(int coins)
        {
            return new Currency(Value + coins);
        }

        public Currency ReduceCoins(int coins)
        {
            return new Currency(Value - coins);
        }
    }
}
