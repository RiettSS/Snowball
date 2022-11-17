using System;
using SceneLoading;
using UnityEngine;
using Zenject;

namespace UI.Popup
{
    public class PausePopUp : MonoBehaviour
    {
        private LevelLoader _levelLoader;
    
        [Inject]
        public void Construct(LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }
    
        public void Replay()
        {
            _levelLoader.LoadLevel(_levelLoader.CurrentLevel);
        }
        
        public void LoadNextLevel()
        {
            var currentSceneNum = Int32.Parse(_levelLoader.CurrentLevel);
            var desiredSceneNum = currentSceneNum + 1;
            _levelLoader.LoadLevel(desiredSceneNum.ToString());
        }

        public void LoadMenu()
        {
            _levelLoader.LoadLevel("MainMenu");
        }
    }
}