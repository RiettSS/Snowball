

using System;

namespace Model
{
    public struct CoinsAmount
    {
        public readonly int Value;

        private const int MinCoins = 0;

        public CoinsAmount(int coinsAmount)
        {
            Value = Math.Clamp(coinsAmount, MinCoins, int.MaxValue);
        }

        public CoinsAmount AddCoins(int coins)
        {
            return new CoinsAmount(Value + coins);
        }

        public CoinsAmount ReduceCoins(int coins)
        {
            return new CoinsAmount(Value - coins);
        }
    }
}
