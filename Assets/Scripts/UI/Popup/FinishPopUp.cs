using System;
using Model;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class FinishPopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private ScoreSystem _scoreSystem;
    private Wallet _wallet;

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
        
    }

    private void OnEnable()
    {
        _scoreText.text = _scoreSystem.Score.ToString();
        _wallet.CoinsAmountChanged += AddCoinsToReward;
    }

    private void OnDisable()
    {
        _wallet.CoinsAmountChanged -= AddCoinsToReward;
    }
}
