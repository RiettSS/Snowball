using System;
using System.Collections.Generic;

namespace Model.DailyReward
{
    [Serializable]
    public struct DailyRewardInformation
    {
        public DateTime LastRewardDay;
        public int Day;
        public List<int> CollectedDays;

        public DailyRewardInformation(DateTime lastRewardDay, int day, List<int> collectedDays)
        {
            LastRewardDay = lastRewardDay;
            Day = day;
            CollectedDays = collectedDays;
        }
    }
}
