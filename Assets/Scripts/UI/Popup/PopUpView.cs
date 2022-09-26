using System;
using UnityEngine;

namespace UI.Popup
{
    public class PopUpView : MonoBehaviour
    {
        public event Action OnClick;
        
        [SerializeField] private PopUpType _type;
        public PopUpType Type => _type;
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Click()
        {
            OnClick?.Invoke();
        }
    }
}
