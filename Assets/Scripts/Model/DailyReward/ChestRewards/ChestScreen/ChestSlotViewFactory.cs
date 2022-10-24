using UnityEngine;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class ChestSlotViewFactory : MonoBehaviour
    {
        [SerializeField] private SlotView _coinsSlotPrefab;
        [SerializeField] private SlotView _crystalsSlotPrefab;
        [SerializeField] private Transform _gridTransform;

        public SlotView CreateCoinsChest()
        {
            return Instantiate(_coinsSlotPrefab, _gridTransform);
        }

        public SlotView CreateCrystalsChest()
        {
            return Instantiate(_crystalsSlotPrefab, _gridTransform);
        }
    }
}