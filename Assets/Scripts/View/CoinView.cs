using UnityEngine;

namespace View
{
    public class CoinView : CollidableView
    {
        [SerializeField] public int Cost;
        
        public override int GetSaveModel()
        {
            return 3;
        }

        public void Release()
        {
            gameObject.SetActive(false);
        }
    }
}
