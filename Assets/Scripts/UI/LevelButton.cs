using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;
    
    private SceneLoader _sceneLoader;
    private int _levelToLoad;

    [Inject]
    public void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        Debug.Log("Button Construct");
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
        //SceneManager.LoadScene(_levelToLoad.ToString());
        _sceneLoader.LoadScene(_levelToLoad.ToString());
    }
}
