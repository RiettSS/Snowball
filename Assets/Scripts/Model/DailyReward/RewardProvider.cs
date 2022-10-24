using System;
using System.Collections.Generic;
using Model.DailyReward.InformationProvider;

namespace Model.DailyReward
{
    public class RewardProvider : IRewardProvider, IDisposable
    {
        private IRewardFactory _factory;
        private List<Reward> _rewards;
        private DailyRewardInformation _rewardInformation;
        
        public RewardProvider(IRewardFactory factory, IRewardInformationProvider rewardInformationProvider)
        {
            _factory = factory;
            _rewards = new List<Reward>();
            _rewardInformation = rewardInformationProvider.GetInformation();
        }

        public List<Reward> GetRewards()
        {
            _rewards.Add(ChestReward());
            _rewards.Add(CoinsReward(100));
            _rewards.Add(CrystalsReward(5));
            _rewards.Add(CoinsReward(300));
            _rewards.Add(CrystalsReward(10));
            _rewards.Add(CoinsReward(500));
            _rewards.Add(CrystalsReward(15));
            _rewards.Add(CoinsReward(700));
            _rewards.Add(CrystalsReward(20));
            _rewards.Add(CoinsReward(900));

            InitializeRewards();

            return _rewards;
        }
        

        private Reward CoinsReward(int coins)
        {
            return _factory.CreateCoinReward(coins);
        }

        private Reward CrystalsReward(int crystals)
        {
            return _factory.CreateCrystalReward(crystals);
        }

        private Reward ChestReward()
        {
            return _factory.CreateChestReward();
        }

        private void InitializeRewards()
        {
            foreach (var reward in _rewards)
            {
                reward.AppliedOnDay += AddAppliedDay;
            }
            
            foreach (var reward in _rewards)
            {
                reward.SetInactive();
            }

            for (int i = 0; i < _rewardInformation.Day; i++)
            {
                _rewards[i].SetActive();
            }
            
            foreach (var reward in _rewards)
            {
                if (_rewardInformation.CollectedDays.Contains(reward.Day))
                {
                    reward.SetInactive();
                }
            }
            
            _rewards[ _rewardInformation.Day - 1].SetTodayBackground();
            
            SaveLoadSystem.SaveRewardInfo(_rewardInformation);
        }
        
        private void AddAppliedDay(int day)
        {
            _rewardInformation.CollectedDays.Add(day);
            SaveLoadSystem.SaveRewardInfo(_rewardInformation);
        }
        
        public void Dispose()
        {
            foreach (var reward in _rewards)
            {
                reward.AppliedOnDay -= AddAppliedDay;
            }
        }
    }
}
