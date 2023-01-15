using System;
using Sound;
using UnityEngine;
using Zenject;

namespace UI.Popup
{
    public class PopUpView : MonoBehaviour
    {
        public event Action OnClick;
        
        [SerializeField] private PopUpType _type;
        [SerializeField] private SoundType _popSound;
        private SoundSystem _soundSystem;
        
        public PopUpType Type => _type;

        [Inject]
        public void Construct(SoundSystem soundSystem)
        {
            _soundSystem = soundSystem;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _soundSystem.PlaySound(_popSound);
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
