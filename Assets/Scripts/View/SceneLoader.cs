using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject LoadingScreen;
    
    public void LoadScene(int sceneNum)
    {
        StartCoroutine(LoadSceneAsync(sceneNum));
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(sceneName);
        
        yield return null;
    }
    
    private IEnumerator LoadSceneAsync(int sceneNum)
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(sceneNum);
        
        yield return null;
    }
}
