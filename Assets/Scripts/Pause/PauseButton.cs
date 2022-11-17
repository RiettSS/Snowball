using UnityEngine;
using Zenject;

namespace Pause
{
    public class PauseButton : MonoBehaviour
    {
        private PauseManager _pauseManager;
        
        [Inject]
        public void Construct(PauseManager pauseManager)
        {
            _pauseManager = pauseManager;
        }

        public void Pause()
        {
            _pauseManager.Pause();
        }

        public void Unpause()
        {
            _pauseManager.Unpause();
        }
    }
}