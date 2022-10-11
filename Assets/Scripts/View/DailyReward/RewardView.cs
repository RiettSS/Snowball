using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View.DailyReward
{
    public class RewardView : MonoBehaviour
    {
        public event Action OpenButtonClicked;

        [SerializeField] private Sprite _background;
        [SerializeField] private Sprite _todayBackground;
        [SerializeField] private TMP_Text _coins;
        [SerializeField] private TMP_Text _dayNum;
        [SerializeField] private GameObject _openButton;

        public void SetCoinsAmount(int coins)
        {
            _coins.SetText("x" + coins.ToString());
        }

        public void SetDayNum(int day)
        {
            _dayNum.SetText("DAY " + day);
        }
        
        public void SetTodayBackground()
        {
            GetComponent<Image>().sprite = _todayBackground;
        }

        private void SetDefaultBackground()
        {
            GetComponent<Image>().sprite = _background;
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
    }
}
