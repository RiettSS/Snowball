using System;
using Model;
using View;
using Zenject;

namespace Presenter
{
    public class IndicatorPresenter : IInitializable, IDisposable
    {
        private IndicatorView _view;
        private LevelIndicator _indicator;
        private IScaler _scaler;

        public IndicatorPresenter(IndicatorView view, LevelIndicator indicator, IScaler scaler)
        {
            _indicator = indicator;
            _view = view;
            _scaler = scaler;
        }
        
        public void Initialize()
        {
            _indicator.LevelUpdated += _view.OnLevelChanged;
            _indicator.LevelPointsLeftUpdated += _view.OnPointsLeftChanged;
            
            _view.OnPointsLeftChanged(_scaler.MaxPoints);
        }

        public void Dispose()
        {
            _indicator.LevelUpdated -= _view.OnLevelChanged;
            _indicator.LevelPointsLeftUpdated -= _view.OnPointsLeftChanged;
        }
    }
}
