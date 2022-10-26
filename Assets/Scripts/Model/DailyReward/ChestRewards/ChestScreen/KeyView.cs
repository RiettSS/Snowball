using System;
using UnityEngine;
using UnityEngine.UI;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class KeyView : MonoBehaviour
    {
        [SerializeField] private Sprite _usedState;
        [SerializeField] private Sprite _default;

        private Image _image;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Lock()
        {
            _image.sprite = _usedState;
        }

        public void Unlock()
        {
            _image.sprite = _default;
        }
    }
}