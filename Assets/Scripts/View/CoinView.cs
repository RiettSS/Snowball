using UnityEngine;

namespace View
{
    public class CoinView : CollidableView
    {
        [SerializeField] private int _cost;
        public int Cost => _cost;

        public void Release()
        {
            gameObject.SetActive(false);
        }
    }
}
