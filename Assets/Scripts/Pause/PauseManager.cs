using UnityEngine;

namespace Pause
{
    public class PauseManager
    {
        private const float PauseTimeScale = 0;
        private float _tempTimeScale;
        private bool _paused;
        
        public void Pause()
        {
            if (_paused)
                return;
            
            _tempTimeScale = Time.timeScale;
            Time.timeScale = PauseTimeScale;
            _paused = true;
        }

        public void Unpause()
        {
            if (!_paused)
                return;
            
            Time.timeScale = _tempTimeScale;
            _paused = false;
        }
    }
}