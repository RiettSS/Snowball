using System;
using Zenject;

namespace Model.DailyReward
{
    public class ChestRewardPresenter : IInitializable, IDisposable
    {
        private Reward _reward;
        private ChestRewardView _view;

        public ChestRewardPresenter(Reward reward, ChestRewardView view)
        {
            _reward = reward;
            _view = view;
        }
        
        public void Initialize()
        {
            _view.OpenButtonClicked += _reward.Apply;
            _reward.Today += _view.SetTodayBackground;
            _reward.Activated += _view.Activate;
            _reward.Deactivated += _view.Deactivate;
            _reward.Applied += _view.Deactivate;
        }

        public void Dispose()
        {
            _view.OpenButtonClicked -= _reward.Apply;
            _reward.Today -= _view.SetTodayBackground;
            _reward.Activated -= _view.Activate;
            _reward.Deactivated -= _view.Deactivate;
            _reward.Applied -= _view.Deactivate;
        }
    }
}
