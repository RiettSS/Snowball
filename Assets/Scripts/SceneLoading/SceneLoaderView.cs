using UnityEngine;

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
            Debug.Log("OnLoaded");
            LoadingScreen.SetActive(false);
        }
    }
}
