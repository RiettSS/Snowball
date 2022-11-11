using SceneLoading;
using TMPro;
using UnityEngine;
using Zenject;

public class LevelHolder : MonoBehaviour
{
    [SerializeField] private TMP_Text _holderText;

    private LevelLoader _levelLoader;
    
    [Inject]
    public void Construct(LevelLoader levelLoader)
    {
        _levelLoader = levelLoader;
    }
    
    private void Start()
    {
        _holderText.SetText("Level " + _levelLoader.CurrentLevel);
    }
}
