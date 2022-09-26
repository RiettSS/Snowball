using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace UI.Popup
{
    public sealed class PopUpShower : IInitializable
    {
        private List<PopUp> _popUps;

        public void Initialize()
        {
            _popUps = new List<PopUp>();
        }
        
        public void AddPopUp(PopUp popUp)
        {
            _popUps.Add(popUp);
            popUp.Hide();
        }
        
        public PopUp ShowPopUp(PopUpType type)
        {
            var popUp = _popUps.FirstOrDefault(x => x.Type == type);

            if (popUp == null)
                throw new NullReferenceException("There is no such popup on the scene");
            
            HideEverything();
            popUp.Show();
            return popUp;
        }

        private void HideEverything()
        {
            foreach (var popUp in _popUps)
            {
                popUp.Hide();
            }
        }
    }
}
