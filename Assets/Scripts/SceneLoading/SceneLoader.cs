using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SceneLoading
{
    public class SceneLoader
    {
        public event Action LoadingStarted;
        public event Action Loaded;
        
        public string CurrentScene { get; private set; }

        public SceneLoader()
        {
            CurrentScene = "AppStartup";
        }
        
        public void LoadScene(string sceneName)
        {
            LoadSceneAsync(sceneName);
            CurrentScene = sceneName;
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
    }
}