using SceneLoading;
using UnityEngine;
using Zenject;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;
    
    private SceneLoader _sceneLoader;

    [Inject]
    public void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
    
    private void Start()
    {
        _sceneLoader.LoadScene(_sceneToLoad);
    }
}
