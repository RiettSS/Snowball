using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;
    
    private SceneLoading.LevelLoader _levelLoader;
    private int _levelToLoad;

    public void Construct(SceneLoading.LevelLoader levelLoader)
    {
        _levelLoader = levelLoader;
    }

    private void Awake()
    {
        _button.onClick.AddListener(Load);
    }

    public void SetLevel(int level)
    {
        _text.text = level.ToString();
        _levelToLoad = level;
    }
    
    private void Load()
    {
        _levelLoader.LoadLevel(_levelToLoad.ToString());
    }
}
