using UI;

namespace Model.DailyReward
{
    public class RewardFactory : IRewardFactory
    {
        private Wallet _wallet;
        private RewardViewFactory _viewFactory;
        private int _dayCount;
        
        public RewardFactory(Wallet wallet, RewardViewFactory viewFactory)    
        {
            _wallet = wallet;
            _viewFactory = viewFactory;
            _dayCount = 1;
        }
        
        public IReward CreateCoinReward(int coins)
        {
            var reward = new CoinsReward(new Currency(coins), _wallet);
            var view = _viewFactory.GetCoinsRewardView();
            view.GetComponent<CoinsRewardView>().SetCoinsAmount(coins);
            var presenter = new CoinsRewardPresenter(reward, view);
            view.SetDayNum(_dayCount);
            reward.Day = _dayCount;
            _dayCount++;
            presenter.Initialize();
            return reward;
        }

        public IReward CreateCrystalReward(int crystals)
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

        public IReward CreateChestReward()
        {
            throw new System.NotImplementedException();
        }
    }
}
