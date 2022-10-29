using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoader
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
        
        private IEnumerator Load(string sceneName)
        {
            LoadingStarted?.Invoke();
            var operation = SceneManager.LoadSceneAsync(sceneName);
            
            while (!operation.isDone)
            {
                yield return new WaitForSeconds(0.5f);
            }
        
            Loaded?.Invoke();
            yield return null;
        }

        private async void LoadSceneAsync(string sceneName)
        {
            LoadingStarted?.Invoke();
            await Task.Run(() => SceneManager.LoadScene(sceneName));
            Loaded?.Invoke();
        }
    }
}