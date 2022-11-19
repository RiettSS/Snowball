using Firebase.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace SceneLoading
{
    public class SceneLoaderView : MonoBehaviour
    {
        [SerializeField] private GameObject LoadingScreen;
        private LevelLoader _levelLoader;
        
        [Inject]
        public void Construct(LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }
        
        public void OnLoadingStarted()
        {
            LoadingScreen.SetActive(true);
        }

        public void OnLoaded()
        {
            LoadingScreen.SetActive(false);
            var sceneName = SceneManager.GetActiveScene().name;
            if (sceneName != "LevelScreen")
            {
                FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart,
                    new Parameter(FirebaseAnalytics.ParameterLevelName, SceneManager.GetActiveScene().name));
            }
            else
            {
                FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart,
                    new Parameter(FirebaseAnalytics.ParameterLevelName, _levelLoader.CurrentLevel));
            }
        }
    }
}
