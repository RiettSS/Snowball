using System;

namespace Model.DailyReward
{
    public class DailyReward
    {
        private RewardProvider _rewardProvider;

        public DailyReward(RewardProvider rewardProvider)
        {
            _rewardProvider = rewardProvider;
        }
        
        public bool TryGetReward()
        {
            var reward = _rewardProvider.GetReward();
            if (reward == null)
                return false;
            
            reward.Execute();
            return true;
        }
    }
}
