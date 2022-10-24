using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Model.DailyReward
{
    public class CrystalsRewardView : MonoBehaviour
    {
        public event Action OpenButtonClicked;

        [SerializeField] private Sprite _background;
        [SerializeField] private Sprite _todayBackground;
        [SerializeField] private TMP_Text _crystals;
        [SerializeField] private TMP_Text _dayNum;
        [SerializeField] private GameObject _openButton;

        public void SetCoinsAmount(int coins)
        {
            _crystals.SetText("x" + coins.ToString());
        }

        public void SetDayNum(int day)
        {
            _dayNum.SetText("DAY " + day);
        }
        
        public void SetTodayBackground()
        {
            GetComponent<Image>().sprite = _todayBackground;
        }
        
        public void Activate()
        {
            _openButton.SetActive(true);
        }

        public void Deactivate()
        {
            _openButton.SetActive(false);
        }
        
        public void OnClick()
        {
            OpenButtonClicked?.Invoke();
        }
        
        private void SetDefaultBackground()
        {
            GetComponent<Image>().sprite = _background;
        }
    }
}