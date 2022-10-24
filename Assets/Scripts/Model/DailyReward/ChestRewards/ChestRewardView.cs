using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Model.DailyReward.ChestRewards
{
    public class ChestRewardView : MonoBehaviour
    {
        public event Action OpenButtonClicked;

        [SerializeField] private Sprite _background;
        [SerializeField] private Sprite _todayBackground;
        [SerializeField] private TMP_Text _dayNum;
        [SerializeField] private GameObject _openButton;

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
