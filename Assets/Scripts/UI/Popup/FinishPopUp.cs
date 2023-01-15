using System;
using Model;
using SceneLoading;
using Sound;
using TMPro;
using UnityEngine;
using Zenject;

public class FinishPopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _coinsText;
    private ScoreSystem _scoreSystem;
    private Wallet _wallet;
    private LevelLoader _levelLoader;
    private SoundSystem _soundSystem;
    private int _coinsOnLevel;

    [Inject]
    public void Construct(ScoreSystem scoreSystem, Wallet wallet, LevelLoader levelLoader, SoundSystem soundSystem)
    {
        _scoreSystem = scoreSystem;
        _wallet = wallet;
        _levelLoader = levelLoader;
        _soundSystem = soundSystem;
    }

    public void LoadNextLevel()
    {
        var currentSceneNum = Int32.Parse(_levelLoader.CurrentLevel);
        var desiredSceneNum = currentSceneNum + 1;
        _levelLoader.LoadLevel(desiredSceneNum.ToString());
    }

    public void Replay()
    {
        _levelLoader.LoadLevel(_levelLoader.CurrentLevel);
    }

    public void LoadMenu()
    {
        _levelLoader.LoadLevel("MainMenu");
    }

    private void AddCoinsToReward(int coins)
    {
        _coinsOnLevel += coins;
    }

    private void Awake()
    {
        _wallet.CoinsAmountAdded += AddCoinsToReward;
    }

    private void OnEnable()
    {
        _scoreText.text = _scoreSystem.Score.ToString();
        _coinsText.SetText(_coinsOnLevel.ToString());
    }

    private void OnDestroy()
    {
        _wallet.CoinsAmountAdded -= AddCoinsToReward;
    }
}
