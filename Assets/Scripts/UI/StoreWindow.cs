using Model;
using TMPro;
using UnityEngine;
using Zenject;

public class StoreWindow : MonoBehaviour
{
    private Wallet _wallet;
    
    [Inject]
    public void Construct(Wallet wallet)
    {
        _wallet = wallet;
    }

    public void SpendCoins()
    {
        _wallet.ReduceCoins(10);
        _wallet.SaveCoins();
    }
}
