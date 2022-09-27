using Model;
using TMPro;
using UnityEngine;
using Zenject;

public class StoreWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;
    //make private
    public Wallet _wallet;
    
    [Inject]
    public void Construct(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void OnEnable()
    {
        UpdateCoins();
    }

    private void UpdateCoins()
    {
        _coinsText.text = _wallet.Coins.ToString();
    }
    
    public void SpendCoins()
    {
        _wallet.ReduceCoins(10);
        _wallet.SaveCoins();
        UpdateCoins();
    }
}
