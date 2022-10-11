using System;

namespace Model.DailyReward
{
    public class RewardProvider : IRewardProvider
    {
        private IRewardFactory _factory;

        public RewardProvider(IRewardFactory factory)
        {
            _factory = factory;
        }

        public IReward GetCoinsReward(int coins)
        {
            var reward = _factory.CreateCoinReward(coins);
            return reward;
        }
    }
}
