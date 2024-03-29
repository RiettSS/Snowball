﻿using Model.DailyReward.ChestRewards;
using Model.DailyReward.ChestRewards.ChestScreen;
using UI;

namespace Model.DailyReward
{
    public class RewardFactory : IRewardFactory
    {
        private Wallet _wallet;
        private RewardViewFactory _viewFactory;
        private PrizeMachine _prizeMachine;
        private int _dayCount;

        public RewardFactory(Wallet wallet, RewardViewFactory viewFactory, PrizeMachine prizeMachine)    
        {
            _wallet = wallet;
            _viewFactory = viewFactory;
            _prizeMachine = prizeMachine;
            _dayCount = 1;
        }
        
        public Reward CreateCoinReward(int coins)
        {
            var reward = new CoinsReward.CoinsReward(new Currency(coins), _wallet);
            var view = _viewFactory.GetCoinsRewardView();
            view.GetComponent<CoinsRewardView>().SetCoinsAmount(coins);
            var presenter = new CoinsRewardPresenter(reward, view);
            view.SetDayNum(_dayCount);
            reward.Day = _dayCount;
            _dayCount++;
            presenter.Initialize();
            return reward;
        }

        public Reward CreateCrystalReward(int crystals)
        {
            var reward = new CrystalsReward(new Currency(crystals), _wallet);
            var view = _viewFactory.GetCrystalsRewardView();
            view.GetComponent<CrystalsRewardView>().SetCoinsAmount(crystals);
            var presenter = new CrystalsRewardPresenter(reward, view);
            view.SetDayNum(_dayCount);
            reward.Day = _dayCount;
            _dayCount++;
            presenter.Initialize();
            return reward;
        }

        public Reward CreateChestReward()
        {
            var reward = new ChestReward(_prizeMachine);
            var view = _viewFactory.GetChestRewardView();
            view.GetComponent<ChestRewardView>();
            var presenter = new ChestRewardPresenter(reward, view);
            view.SetDayNum(_dayCount);
            reward.Day = _dayCount;
            _dayCount++;
            presenter.Initialize();
            return reward;
        }
    }
}
