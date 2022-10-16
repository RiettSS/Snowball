using System;
using UI.Popup;
using UnityEngine;
using Zenject;

namespace Model
{
    public class UIEventListener : IInitializable, IDisposable
    {
        private Ball _ball;
        private PopUpShower _popUpShower;

        public UIEventListener(Ball ball, PopUpShower popUpShower)
        {
            _ball = ball;
            _popUpShower = popUpShower;
        }
        
        public void Initialize()
        {
            _ball.OnSmashed += OnBallSmashed;
        }
        
        public void Dispose()
        {
            
        }

        private void OnBallSmashed()
        {
            _popUpShower.ShowPopUp(PopUpType.Lose);
        }
    }
}
