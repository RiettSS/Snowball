using System;
using Model;

namespace Store
{
    [Serializable]
    public struct SkinPrice
    {
        public int Coins => _coins.Value;
        public int Crystals => _crystals.Value;
        
        private readonly Currency _coins;
        private readonly Currency _crystals;

        public SkinPrice(Currency coins, Currency crystals)
        {
            _coins = coins;
            _crystals = crystals;
        }
    } 
}