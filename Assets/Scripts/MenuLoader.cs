using SceneLoading;
using UnityEngine;
using Zenject;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;
    
    private LevelLoader _levelLoader;

    [Inject]
    public void Construct(LevelLoader levelLoader)
    {
        _levelLoader = levelLoader;
    }
    
    private void Start()
    {
        _levelLoader.LoadLevel(_sceneToLoad);
    }
}
