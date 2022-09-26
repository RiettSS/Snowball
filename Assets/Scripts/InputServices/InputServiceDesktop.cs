using System;
using UnityEngine;

namespace InputServices
{
    public class InputServiceDesktop : MonoBehaviour, IInputService
    {
        public event Action OnMoveLeft;
        public event Action OnMoveRight;

        private void Update()
        {
            if(Input.GetKey(KeyCode.A))
                OnMoveLeft?.Invoke();
            
            if(Input.GetKey((KeyCode.D)))
                OnMoveRight?.Invoke();
        }
    }
}
