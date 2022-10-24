using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Zenject;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class PrizeMachine : IInitializable, IDisposable
    {
        private SlotProvider _slotProvider;
        private ChestRewardCalculator _rewardCalculator;
        private Wallet _wallet;
        private List<Slot> _slots;

        public PrizeMachine(SlotProvider slotProvider, Wallet wallet)
        {
            _slotProvider = slotProvider;
            _wallet = wallet;

            _rewardCalculator = new ChestRewardCalculator();
        }
        
        public void Initialize()
        {
            _slots = _slotProvider.GetSlots();
            _rewardCalculator.RewardCalculated += GetReward;
            _rewardCalculator.NoReward += GameOver;

            foreach (var slot in _slots)
            {
                slot.Clicked += OpenSlot;
            }
        }

        public void Dispose()
        {
            _rewardCalculator.RewardCalculated -= GetReward;
            _rewardCalculator.NoReward -= GameOver;
            
            foreach (var slot in _slots)
            {
                slot.Clicked -= OpenSlot;
            }
        }

        private void OpenSlot(Slot slot)
        {
            if (_rewardCalculator.AddSlot(slot))
            {
                slot.Open();
            }
        }

        private void GetReward(int amount, CurrencyType type)
        {
            if (type == CurrencyType.Coins)
            {
                _wallet.AddCoins(amount);
            } 
            else if (type == CurrencyType.Crystals)
            {
                _wallet.AddCrystals(amount);
            }
        }

        private void GameOver()
        {
            Debug.Log("No Reward");
        }
    }
}