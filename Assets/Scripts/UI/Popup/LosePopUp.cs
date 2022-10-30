using Model;
using SceneLoading;
using TMPro;
using UnityEngine;
using Zenject;

public class LosePopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private ScoreSystem _scoreSystem;
    private SceneLoader _sceneLoader;
    
    [Inject]
    public void Construct(ScoreSystem scoreSystem, SceneLoader sceneLoader)
    {
        _scoreSystem = scoreSystem;
        _sceneLoader = sceneLoader;
    }
    
    public void Replay()
    {
        _sceneLoader.LoadScene(_sceneLoader.CurrentScene);
    }

    public void LoadMenu()
    {
        _sceneLoader.LoadScene("MainMenu");
    }

    private void OnEnable()
    {
        _scoreText.SetText(_scoreSystem.Score.ToString());
    }
}
