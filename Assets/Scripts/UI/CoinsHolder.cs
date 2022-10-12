using System;
using Model;
using TMPro;
using UnityEngine;
using Zenject;

public class CoinsHolder : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;

    private Wallet _wallet;

    [Inject]
    public void Construct(Wallet wallet)
    {
        _wallet = wallet;
    }
    
    private void OnEnable()
    {
        UpdateCoins(_wallet.Coins);
        _wallet.CoinsAmountChanged += UpdateCoins;
    }

    private void OnDisable()
    {
        _wallet.CoinsAmountChanged -= UpdateCoins;
    }

    private void UpdateCoins(int coins)
    {
        _coinsText.SetText(coins.ToString());
    }
}
