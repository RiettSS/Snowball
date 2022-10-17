using System.Collections.Generic;
using BallSkinLoader;
using Model;
using Store;

namespace SkinDictionaries
{
    public static class SkinPrices
    {
        private static readonly Dictionary<SkinType, SkinPrice> _dictionary = new Dictionary<SkinType, SkinPrice>()
        {
            { SkinType.Default, Price(0,0) },
            { SkinType.Magma, Price(10, 0) },
            { SkinType.Spike, Price(30, 0) },
            { SkinType.Thread, Price(50, 0) },
        };

        public static SkinPrice GetPrice(SkinType type)
        {
            return _dictionary[type];
        }

        private static SkinPrice Price(int coins, int crystals)
        {
            return new SkinPrice(new Currency(coins), new Currency(crystals));
        }
    }
}