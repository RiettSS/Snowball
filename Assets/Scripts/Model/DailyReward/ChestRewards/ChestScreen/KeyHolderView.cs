using System.Collections.Generic;

using UnityEngine;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class KeyHolderView : MonoBehaviour
    {
        [SerializeField] private List<KeyView> _keys;
        private int _count;

        public void LockKey()
        {
           _keys[_keys.Count - 1 - _count++].Lock();
        }
    }
}