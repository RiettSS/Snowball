using UnityEngine;
using View.DailyReward;

namespace Model.DailyReward
{
    public class RewardViewFactory : MonoBehaviour
    {
        [SerializeField] private Transform _contentView;

        [SerializeField] private RewardView _coinsPrefab;
        //[SerializeField] private RewardView _chestPrefab;

        public RewardView GetCoinsRewardView()
        {
            return Instantiate(_coinsPrefab, _contentView.transform);
        }

        public RewardView GetChestRewardView()
        {//TODO
            return Instantiate(_coinsPrefab, _contentView.transform);
        }
    }
}
