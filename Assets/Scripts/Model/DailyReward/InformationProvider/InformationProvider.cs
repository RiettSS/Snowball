using System;
using System.Collections.Generic;

namespace Model.DailyReward.InformationProvider
{
    public class InformationProvider : IRewardInformatioProvider
    {
        private DailyRewardInformation _rewardInformation;
        
        public InformationProvider()
        {
            _rewardInformation = SaveLoadSystem.LoadRewardInfo();
        }

        public DailyRewardInformation GetInfo()
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
        
        private int CurrentDay()
        {
            return _rewardInformation.Day;
        }

        private DateTime LastRewardDay()
        {
            return _rewardInformation.LastRewardDay;
        }

        private List<int> CollectedDays()
        {
            return _rewardInformation.CollectedDays;
        }
    }
}
