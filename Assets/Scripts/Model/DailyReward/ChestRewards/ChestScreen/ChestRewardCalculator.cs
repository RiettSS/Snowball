using System;
using System.Collections.Generic;
using UI;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class ChestRewardCalculator
    {
        public event Action<int, CurrencyType> RewardCalculated;
        public event Action NoReward;
        
        private int _count;
        private const int MaxCount = 3;
        private List<Slot> _slots;

        public ChestRewardCalculator()
        {
            _slots = new List<Slot>();
        }
        
        public bool AddSlot(Slot slot)
        {
            if (_count < MaxCount)
            {
                _slots.Add(slot);
                _count++;
                if (_slots.Count == 3)
                {
                    Reward();
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reward()
        {
            if (_slots[0].Type == _slots[1].Type && _slots[1].Type == _slots[2].Type)
            {
                if (_slots[0].CurrencyAmount == _slots[1].CurrencyAmount &&
                    _slots[1].CurrencyAmount == _slots[2].CurrencyAmount)
                {
                    RewardCalculated?.Invoke(_slots[0].CurrencyAmount, _slots[0].Type);
                }
                else
                {
                    NoReward?.Invoke();
                }
            }
            else
            {
                NoReward?.Invoke();
            }
        }
    }
}