using System;
using System.Collections.Generic;
using Zenject;

namespace Model.DailyReward
{
    public class DailyRewardService : IInitializable
    {
        private IRewardProvider _rewardProvider;
        private List<IReward> _list;
        private DateTime _lastRewardDay;
        private int _rewardDay;

        public DailyRewardService(IRewardProvider rewardProvider)
        {
            _rewardProvider = rewardProvider;
            _list = new List<IReward>();
            _lastRewardDay = new DateTime(2022, 10, 10);
        }

        public void Initialize()
        {
            _list.Add(_rewardProvider.GetCoinsReward(100));
            _list.Add(_rewardProvider.GetCoinsReward(200));
            _list.Add(_rewardProvider.GetCoinsReward(300));
            
            
        }
    }
}
