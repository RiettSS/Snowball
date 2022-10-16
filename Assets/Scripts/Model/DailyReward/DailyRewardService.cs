using System;
using System.Collections.Generic;
using Model.DailyReward.InformationProvider;
using Zenject;

namespace Model.DailyReward
{
    public class DailyRewardService : IInitializable, IDisposable
    {
        private IRewardProvider _rewardProvider;
        private List<IReward> _rewards;

        private DailyRewardInformation _rewardInformation;


        public DailyRewardService(IRewardProvider rewardProvider, IRewardInformationProvider rewardInformationProvider)
        {
            _rewardProvider = rewardProvider;
            _rewards = new List<IReward>();
            _rewardInformation = rewardInformationProvider.GetInformation();
        }

        public void Initialize()
        {
            _rewards = _rewardProvider.GetRewards();

            //TODO вынести логику в другой класс
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
        
        public void Dispose()
        {
            foreach (var reward in _rewards)
            {
                reward.AppliedOnDay -= AddAppliedDay;
            }
        }

        private void AddAppliedDay(int day)
        {
            _rewardInformation.CollectedDays.Add(day);
            SaveLoadSystem.SaveRewardInfo(_rewardInformation);
        }
    }
}
