using System.Collections.Generic;

namespace Model.DailyReward
{
    public interface IRewardProvider
    {
        List<Reward> GetRewards();
        
    }
}
