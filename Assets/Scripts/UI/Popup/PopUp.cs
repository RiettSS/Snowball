using System;
using UnityEngine;

namespace UI.Popup
{
    public class PopUp
    {
        public event Action OnShow;
        public event Action OnHide;

        private readonly PopUpShower _popUpShower;

        public PopUpType Type { get; }

        public PopUp(PopUpType type, PopUpShower popUpShower)
        {
            Type = type;
            _popUpShower = popUpShower;
        }
        
        public void Show()
        {
            OnShow?.Invoke();
        }

        public void Hide()
        {
            OnHide?.Invoke();
        }

        public void OnClick()
        {
            Hide();
        }

        public void Init()
        {
            _popUpShower.AddPopUp(this);
        }
    }
}