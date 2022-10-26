using UnityEngine;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class PrizeMachineView : MonoBehaviour
    {
        [SerializeField] private GameObject _dailyRewards;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _closeButton;
        [SerializeField] private KeyHolderView keyHolderView;
        private void Start()
        {
            _closeButton.SetActive(false);
        }

        public void Show()
        {
            _dailyRewards.SetActive(false);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _mainMenu.SetActive(true);
        }

        public void Win()
        {
            AllowToHide();
        }

        public void Lose()
        {
            AllowToHide();
        }

        public void OnSlotOpen()
        {
            keyHolderView.LockKey();
        }
        
        private void AllowToHide()
        {
            _closeButton.SetActive(true);
        }
    }
}