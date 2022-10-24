using System;
using TMPro;
using UnityEngine;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currencyAmount;
        [SerializeField] private GameObject _foreground;

        public event Action Click;
        
        public void Lock()
        {
            _foreground.SetActive(true);
        }

        public void Unlock()
        {
            _foreground.SetActive(false);
        }

        public void SetCurrencyAmount(float value)
        {
            _currencyAmount.SetText(value.ToString());
        }
        
        public void OnClick()
        {
            Click?.Invoke();
        }
    }
}