using Model;
using SceneLoading;
using Sound;
using TMPro;
using UnityEngine;
using Zenject;

public class LosePopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private ScoreSystem _scoreSystem;
    private LevelLoader _levelLoader;
    private SoundSystem _soundSystem;

    [Inject]
    public void Construct(ScoreSystem scoreSystem, LevelLoader levelLoader, SoundSystem soundSystem)
    {
        _scoreSystem = scoreSystem;
        _levelLoader = levelLoader;
        _soundSystem = soundSystem;
    }
    
    public void Replay()
    {
        _levelLoader.LoadLevel(_levelLoader.CurrentLevel);
    }

    public void LoadMenu()
    {
        _levelLoader.LoadLevel("MainMenu");
    }

    private void OnEnable()
    {
        _scoreText.SetText(_scoreSystem.Score.ToString());
    }
}
