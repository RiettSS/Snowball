using System;
using UnityEngine;

namespace InputServices
{
    public class InputServiceAndroid : MonoBehaviour, IInputService
    {
        public event Action OnMoveLeft;
        public event Action OnMoveRight;

        private bool _leftPressed;
        private bool _rightPressed;

        public void LeftButtonPressed()
        {
            _leftPressed = true;
        }
    
        public void LeftButtonUnpressed()
        {
            _leftPressed = false;
        }
    
        public void RightButtonPressed()
        {
            _rightPressed = true;
        }
    
        public void RightButtonUnpressed()
        {
            _rightPressed = false;
        }

        private void Update()
        {
            if(_leftPressed)
                OnMoveLeft?.Invoke();
        
            if(_rightPressed)
                OnMoveRight?.Invoke();
        }
    }
}
