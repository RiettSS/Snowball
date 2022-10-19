using System;
using UI;
using UnityEngine;
using Zenject;

namespace Model.DailyReward
{
    public class CoinsRewardPresenter : IInitializable, IDisposable
    {
        private IReward _reward;
        private CoinsRewardView _view;

        public CoinsRewardPresenter(IReward reward, CoinsRewardView view)
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
