using System;
using UnityEngine;

namespace View
{
    public abstract class CollidableView : MonoBehaviour
    {
        public event Action OnCollisionDetected;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BallView ballView))
            {
                OnCollisionDetected?.Invoke();
            }
        }
    }
}
