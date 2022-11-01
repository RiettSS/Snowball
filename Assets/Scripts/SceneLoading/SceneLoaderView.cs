using Firebase.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoading
{
    public class SceneLoaderView : MonoBehaviour
    {
        [SerializeField] private GameObject LoadingScreen;
        
        public void OnLoadingStarted()
        {
            LoadingScreen.SetActive(true);
        }

        public void OnLoaded()
        {
            LoadingScreen.SetActive(false);
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart,
                new Parameter(FirebaseAnalytics.ParameterLevelName, SceneManager.GetActiveScene().name));
        }
    }
}
