using System;

namespace Model
{
    [Serializable]
    public struct Currency
    {
        public readonly int Value;

        private const int MinAmount = 0;

        public Currency(int coinsAmount)
        {
            Value = Math.Clamp(coinsAmount, MinAmount, int.MaxValue);
        }

        public Currency Add(int amount)
        {
            return new Currency(Value + amount);
        }

        public Currency Reduce(int amount)
        {
            return new Currency(Value - amount);
        }
    }
}
