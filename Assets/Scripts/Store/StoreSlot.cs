using System;
using BallSkinLoader;
using Firebase.Analytics;
using SkinDictionaries;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Store
{
    public class StoreSlot
    {
        public event Action<SlotState> StateChanged;
        public readonly SkinType SkinType;
        public readonly SkinPrice Price;
        public bool LockState { get; private set; }

        private readonly SkinStorage _storage;

        public StoreSlot(SkinType skinType, SkinStorage storage)
        {
            SkinType = skinType;
            Price = SkinPrices.GetPrice(skinType);
            _storage = storage;
            _storage.EquippedSkinChanged += CalculateState;
            
            TryLock();
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

            FirebaseAnalytics.LogEvent("store_skin_bought",
                new Parameter("skin_name", SkinNames.GetSkinName(SkinType)));

            return _storage.TryBuy(SkinType);
        }

        private void TryLock()
        {
            if (_storage.IsBought(SkinType))
                LockState = false;
            else
                LockState = true;
        }
    }
}