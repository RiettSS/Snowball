using UnityEngine;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class PrizeMachineView : MonoBehaviour
    {
        [SerializeField] private GameObject _dailyRewards;
        [SerializeField] private GameObject _mainMenu;

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
    }
}