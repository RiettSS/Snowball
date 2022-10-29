using UnityEngine;

namespace SceneLoader
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
        }
    }
}
