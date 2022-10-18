using Model;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class CrystalsHolder : MonoBehaviour
    {
        [SerializeField] private TMP_Text _crystalsText;

        private Wallet _wallet;

        [Inject]
        public void Construct(Wallet wallet)
        {
            _wallet = wallet;
        }
    
        private void OnEnable()
        {
            UpdateCrystals(_wallet.Crystals);
            _wallet.CrystalsAmountChanged += UpdateCrystals;
        }

        private void OnDisable()
        {
            _wallet.CrystalsAmountChanged -= UpdateCrystals;
        }

        private void UpdateCrystals(int coins)
        {
            _crystalsText.SetText(coins.ToString());
        }
    }
}