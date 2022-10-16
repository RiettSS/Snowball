using System;
using System.Collections.Generic;
using UI.Popup;
using UnityEngine;
using Zenject;

namespace Model
{
    public class Tutorial : IInitializable, IDisposable
    {
        private PopUpShower _popUpShower;
        private Ball _ball;
        private PopUp _popUp;
        private List<PopUpType> _popUpTypes = new List<PopUpType>() {PopUpType.TutorialWelcome, PopUpType.TutorialControl};

        private int _popUpNum;
        private bool _growPopUpShown;

        public Tutorial(PopUpShower popUpShower, Ball ball)
        {
            _popUpShower = popUpShower;
            _ball = ball;
        }

        public void Initialize()
        {
            _ball.OnUpgrade += TryShowGrowPopUp;
        }

        public void Dispose()
        {
            _ball.OnUpgrade -= TryShowGrowPopUp;
        }

        public void StartTutorial()
        {
            _popUpNum = 0;
            _ball.DisableControl();
            TryShowNextPopUp();
        }

        public void ShowPopUp(PopUpType type)
        {
            _popUp = _popUpShower.ShowPopUp(type);
            SlowDownTimeWhile(_popUp);
        }

        private void TryShowNextPopUp()
        {
            if (_popUpNum >= _popUpTypes.Count)
                return;

            ShowPopUp(_popUpTypes[_popUpNum]);
            _popUpNum++;
        }

        private void SlowDownTimeWhile(PopUp popUp)
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.2f * 0.02f;
            popUp.OnHide += OnPopUpHide;
        }

        private void OnPopUpHide()
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            _popUp.OnHide -= OnPopUpHide;
            TryShowNextPopUp();
        }

        public void EndTutorial()
        {
            _ball.EnableControl();
        }

        private void TryShowGrowPopUp()
        {
            if (_growPopUpShown)
                return;

            ShowPopUp(PopUpType.TutorialGrow);
            _growPopUpShown = true;
            EndTutorial();
        }
    }
}
