using System;
using LevelLoading;
using UnityEngine;

namespace View
{
    public abstract class CollidableView : MonoBehaviour, ISavableObject
    {
        public event Action OnCollisionDetected;

        public virtual int GetSaveModel()
        {
            return 1;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BallView ballView))
            {
                OnCollisionDetected?.Invoke();
            }
        }
    }
}
