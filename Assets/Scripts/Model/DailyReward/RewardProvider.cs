using System;
using System.Collections.Generic;

namespace Model.DailyReward
{
    public class RewardProvider : IRewardProvider
    {
        private IRewardFactory _factory;
        private List<IReward> _rewards;
        
        public RewardProvider(IRewardFactory factory)
        {
            _factory = factory;
            _rewards = new List<IReward>();
        }

        public List<IReward> GetRewards()
        {
            _rewards.Add(GetCoinsReward(100));
            _rewards.Add(GetCoinsReward(200));
            _rewards.Add(GetCoinsReward(300));
            _rewards.Add(GetCoinsReward(400));
            _rewards.Add(GetCoinsReward(500));
            _rewards.Add(GetCoinsReward(600));
            _rewards.Add(GetCoinsReward(700));
            _rewards.Add(GetCoinsReward(800));
            _rewards.Add(GetCoinsReward(900));

            return _rewards;
        }

        public IReward GetCoinsReward(int coins)
        {
            var reward = _factory.CreateCoinReward(coins);
            return reward;
        }
    }
}
