using System;
using System.Collections.Generic;

namespace Model.DailyReward.InformationProvider
{
    public class RewardInformationProvider : IRewardInformationProvider
    {
        private DailyRewardInformation _rewardInformation;
        
        public RewardInformationProvider()
        {
            _rewardInformation = SaveLoadSystem.LoadRewardInfo();
        }

        public DailyRewardInformation GetInformation()
        {
            return CalculateRewardInfo();
        }

        private DailyRewardInformation CalculateRewardInfo()
        {
            if (DateTime.Today.Day - _rewardInformation.LastRewardDay.Day == 0)
            {
                return new DailyRewardInformation(DateTime.Today, _rewardInformation.Day, _rewardInformation.CollectedDays);
            } else
            if (DateTime.Today.Day - _rewardInformation.LastRewardDay.Day == 1)
            {
                return new DailyRewardInformation(DateTime.Today, _rewardInformation.Day + 1, _rewardInformation.CollectedDays);
            } else
            {
                return new DailyRewardInformation(DateTime.Today, 1, new List<int>());
            }
        }
    }
}
