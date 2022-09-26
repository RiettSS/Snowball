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

        public IndicatorPresenter(IndicatorView view, LevelIndicator indicator)
        {
            _indicator = indicator;
            _view = view;
        }
        
        public void Initialize()
        {
            _indicator.LevelUpdated += _view.OnLevelChanged;
            _indicator.LevelPointsLeftUpdated += _view.OnPointsLeftChanged;
        }

        public void Dispose()
        {
            _indicator.LevelUpdated -= _view.OnLevelChanged;
            _indicator.LevelPointsLeftUpdated -= _view.OnPointsLeftChanged;
        }
    }
}
