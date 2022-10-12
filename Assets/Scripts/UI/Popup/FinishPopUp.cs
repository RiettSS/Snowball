using System;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class FinishPopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _coinsText;
    private ScoreSystem _scoreSystem;
    private Wallet _wallet;
    private int _coinsOnLevel;

    [Inject]
    public void Construct(ScoreSystem scoreSystem, Wallet wallet)
    {
        _scoreSystem = scoreSystem;
        _wallet = wallet;
    }

    public void LoadScene(string sceneNum)
    {
        SceneManager.LoadSceneAsync(sceneNum);
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
