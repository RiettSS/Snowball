using System;
using Zenject;

namespace Model.DailyReward
{
    public class CrystalsRewardPresenter : IInitializable, IDisposable
    {
        private IReward _reward;
        private CrystalsRewardView _view;

        public CrystalsRewardPresenter(IReward reward, CrystalsRewardView view)
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