using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SceneLoading
{
    public class LevelLoader
    {
        public event Action LoadingStarted;
        public event Action Loaded;
        
        public string CurrentLevel { get; private set; }

        public LevelLoader()
        {
            CurrentLevel = "AppStartup";
        }
        
        public void LoadLevel(string sceneName)
        {
            CurrentLevel = sceneName;
            if (sceneName == "MainMenu" || sceneName == "1")
            {
                LoadSceneAsync(sceneName);
            }
            else
            {
                LoadLevelByName(sceneName);
            }
        }

        private async void LoadSceneAsync(string sceneName)
        {
            LoadingStarted?.Invoke();

            var operation = SceneManager.LoadSceneAsync(sceneName);

            while (!operation.isDone)
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(200);
                });
            }

            Loaded?.Invoke();
        }

        private void LoadLevelByName(string levelName)
        {
            LoadSceneAsync("LevelScreen");
        }
    }
}