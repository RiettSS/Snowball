using System.Collections.Generic;
using Zenject;

namespace Model.DailyReward
{
    public class DailyRewardService : IInitializable
    {
        private IRewardProvider _rewardProvider;
        private List<Reward> _rewards;

        private DailyRewardInformation _rewardInformation;


        public DailyRewardService(IRewardProvider rewardProvider)
        {
            _rewardProvider = rewardProvider;
            _rewards = new List<Reward>();
        }

        public void Initialize()
        {
            _rewardProvider.GetRewards();
        }
    }
}
