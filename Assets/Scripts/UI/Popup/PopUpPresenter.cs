using System;
using UnityEngine;
using Zenject;

namespace UI.Popup
{
    public class PopUpPresenter : IInitializable, IDisposable
    {
        private PopUp _popUp;
        private PopUpView _view;

        public PopUpPresenter(PopUp popUp, PopUpView view)
        {
            _popUp = popUp;
            _view = view;
        }
        
        public void Initialize()
        {
            _popUp.OnShow += _view.Show;
            _popUp.OnHide += _view.Hide;
            _view.OnClick += _popUp.OnClick;
            _popUp.Init();
        }

        public void Dispose()
        {
            _popUp.OnShow -= _view.Show;
            _popUp.OnHide -= _view.Hide;
            _view.OnClick -= _popUp.OnClick;
        }
    }
}
