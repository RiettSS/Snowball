using Model.DailyReward.ChestRewards;
using UnityEngine;

namespace Model.DailyReward
{
    public class RewardViewFactory : MonoBehaviour
    {
        [SerializeField] private Transform _contentView;
        [SerializeField] private CoinsRewardView _coinsPrefab;
        [SerializeField] private CrystalsRewardView _crystalsPrefab;
        [SerializeField] private ChestRewardView _chestPrefab;

        public CoinsRewardView GetCoinsRewardView()
        {
            return Instantiate(_coinsPrefab, _contentView.transform);
        }

        public CrystalsRewardView GetCrystalsRewardView()
        {
            return Instantiate(_crystalsPrefab, _contentView.transform);
        }

        public ChestRewardView GetChestRewardView()
        {
            return Instantiate(_chestPrefab, _contentView.transform);
        }
    }
}
