using System;
using UnityEngine;

public class LevelBrowser : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private LevelButton _buttonPrefab;
    [SerializeField] private Transform _levelsParent;
    [SerializeField] private SceneLoader _sceneLoader;

    private void Awake()
    {
        for (int i = 1; i <= _levelCount; i++)
        {
            var button = Instantiate(_buttonPrefab, _levelsParent);
            button.Construct(_sceneLoader);
            button.SetLevel(i);
        }
    }
}
