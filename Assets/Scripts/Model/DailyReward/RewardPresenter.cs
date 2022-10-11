using System;
using UI;
using UnityEngine;
using View.DailyReward;
using Zenject;

namespace Model.DailyReward
{
    public class RewardPresenter : IInitializable, IDisposable
    {
        private IReward _reward;
        private RewardView _view;

        public RewardPresenter(IReward reward, RewardView view)
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
            //_reward.DayChaged += _view.SetDayNum;
            _reward.Applied += _view.Deactivate;
        }

        public void Dispose()
        {
            Debug.Log("Disposed");
            _view.OpenButtonClicked -= _reward.Apply;
            _reward.Today -= _view.SetTodayBackground;
            _reward.Activated -= _view.Activate;
            _reward.Deactivated -= _view.Deactivate;
            //_reward.DayChaged -= _view.SetDayNum;
            _reward.Applied -= _view.Deactivate;
        }
    }
}
