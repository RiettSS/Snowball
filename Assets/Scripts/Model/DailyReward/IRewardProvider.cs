using System.Collections.Generic;

namespace Model.DailyReward
{
    public interface IRewardProvider
    {
        List<IReward> GetRewards();

        IReward CoinsReward(int coins);
    }
}
