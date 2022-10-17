using System;
using Model;
using SkinDictionaries;
using Store;
using UnityEngine;

namespace BallSkinLoader
{
    public class SkinStorage
    {
        public event Action<SkinType> EquippedSkinChanged;

        public SkinType CurrentSkin => _skinsInformation.CurrentSkin;
        
        private SkinsInformation _skinsInformation;
        private Wallet _wallet;

        public SkinStorage(Wallet wallet)
        {
            _skinsInformation = SaveLoadSystem.LoadSkinsInfo();
            _wallet = wallet;
        }

        public bool IsBought(SkinType type)
        {
            if (_skinsInformation.Skins.Contains(type))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TryBuy(SkinType type)
        {
            var skinPrice = SkinPrices.GetPrice(type);
            if (skinPrice.Coins > _wallet.Coins || skinPrice.Crystals > _wallet.Crystals)
                return false;

            _wallet.ReduceCoins(skinPrice.Coins);
            _wallet.ReduceCrystals(skinPrice.Crystals);
            _wallet.SaveCoins();
            _skinsInformation.AddSkin(type);
            SaveLoadSystem.SaveSkinsInfo(_skinsInformation);
            return true;
        }

        public void Equip(SkinType type)
        {
            _skinsInformation.SetSkin(type);
            EquippedSkinChanged?.Invoke(type);
            SaveLoadSystem.SaveSkinsInfo(_skinsInformation);
        }
    }
}