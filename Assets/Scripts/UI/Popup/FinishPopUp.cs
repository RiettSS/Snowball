using System;
using Model;
using SceneLoading;
using TMPro;
using UnityEngine;
using Zenject;

public class FinishPopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _coinsText;
    private ScoreSystem _scoreSystem;
    private Wallet _wallet;
    private SceneLoader _sceneLoader;
    private int _coinsOnLevel;

    [Inject]
    public void Construct(ScoreSystem scoreSystem, Wallet wallet, SceneLoader sceneLoader)
    {
        _scoreSystem = scoreSystem;
        _wallet = wallet;
        _sceneLoader = sceneLoader;
    }

    public void LoadNextLevel()
    {
        var currentSceneNum = Int32.Parse(_sceneLoader.CurrentScene);
        var desiredSceneNum = currentSceneNum + 1;
        _sceneLoader.LoadScene(desiredSceneNum.ToString());
    }

    public void Replay()
    {
        _sceneLoader.LoadScene(_sceneLoader.CurrentScene);
    }

    public void LoadMenu()
    {
        _sceneLoader.LoadScene("MainMenu");
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
