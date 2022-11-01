using SceneLoading;
using TMPro;
using UnityEngine;
using Zenject;

public class LevelHolder : MonoBehaviour
{
    [SerializeField] private TMP_Text _holderText;

    private SceneLoader _sceneLoader;
    
    [Inject]
    public void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
    
    private void Start()
    {
        _holderText.SetText("Level " + _sceneLoader.CurrentScene);
    }
}
