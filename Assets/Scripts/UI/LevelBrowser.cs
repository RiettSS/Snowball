using Model;
using UnityEngine;
using Zenject;

public class LevelBrowser : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private LevelButton _buttonPrefab;
    [SerializeField] private LevelButton _lockedButtonPrefab;
    [SerializeField] private Transform _contentView;

    private SceneLoading.LevelLoader _levelLoader;
    private int _unlockedLevels;

    [Inject]
    public void Construct(SceneLoading.LevelLoader levelLoader)
    {
        _levelLoader = levelLoader;
    }
    
    private void Awake()
    {
        _unlockedLevels = SaveLoadSystem.LoadUnlockedLevelsCount();
        
        for (int i = 1; i <= _unlockedLevels; i++)
        {
            var button = Instantiate(_buttonPrefab, _contentView);
            button.Construct(_levelLoader);
            button.SetLevel(i);
        }
        
        for (int i = _unlockedLevels + 1; i <= _levelCount; i++)
        {
            var button = Instantiate(_lockedButtonPrefab, _contentView);
            button.Construct(_levelLoader);
            button.SetLevel(i);
        }
    }
}
