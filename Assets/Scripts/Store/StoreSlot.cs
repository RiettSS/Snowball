using System;
using BallSkinLoader;
using SkinDictionaries;
using UnityEngine;

namespace Store
{
    public class StoreSlot
    {
        public event Action<SlotState> StateChanged;
        public readonly SkinType SkinType;
        public readonly SkinPrice Price;

        private readonly SkinStorage _storage;

        public StoreSlot(SkinType skinType, SkinStorage storage)
        {
            SkinType = skinType;
            Price = SkinPrices.GetPrice(skinType);
            _storage = storage;

            _storage.EquippedSkinChanged += CalculateState;
        }

        public void OnBuyPressed()
        {
            if(TryBuy())
                StateChanged?.Invoke(SlotState.Equipable);
        }

        public void OnEquipPressed()
        {
            StateChanged?.Invoke(SlotState.Equipable);
            Equip();
        }

        private void Equip()
        {
            _storage.Equip(SkinType);
        }

        private void CalculateState(SkinType type)
        {
            if(type == SkinType)
                StateChanged?.Invoke(SlotState.Equipped);

            if (type != SkinType)
            {
                StateChanged?.Invoke(SlotState.Equipable);
            }
                
            if(!_storage.IsBought(SkinType))
                StateChanged?.Invoke(SlotState.Buyable);
        }

        private bool TryBuy()
        {
            if (_storage.IsBought(SkinType))
                return false;

            return _storage.TryBuy(SkinType);
        }
    }
}