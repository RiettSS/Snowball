using System;
using BallSkinLoader;
using SkinDictionaries;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Store
{
    public class StoreSlotView : MonoBehaviour
    {
        public event Action BuyButtonPressed; 
        public event Action EquipButtonPressed; 

        [SerializeField] private TMP_Text _skinName;
        [SerializeField] private TMP_Text _coinsPrice;
        [SerializeField] private TMP_Text _crystalsPrice;
        [SerializeField] private Transform _buyButton;
        [SerializeField] private Transform _equipButton;
        [SerializeField] private TMP_Text _equippedText;
        [SerializeField] private Transform _prefabSpawnPoint;

        private SkinType _skinType;

        public void Construct(SkinType skinType)
        {
            _skinType = skinType;
            ChangeState(SlotState.Buyable);
            var price = SkinPrices.GetPrice(skinType);
            _coinsPrice.SetText(price.Coins.ToString());
            _crystalsPrice.SetText(price.Crystals.ToString());
        }

        public void Buy()
        {
            BuyButtonPressed?.Invoke();
        }

        public void Equip()
        {
            EquipButtonPressed?.Invoke();
        }

        public void ChangeState(SlotState state)
        {
            switch (state)
            {
                case SlotState.Buyable:
                    _buyButton.gameObject.SetActive(true);
                    _equipButton.gameObject.SetActive(false);
                    _equippedText.gameObject.SetActive(false);
                    _coinsPrice.gameObject.SetActive(true);
                    _crystalsPrice.gameObject.SetActive(true);
                    break;
                case SlotState.Equipable:
                    _buyButton.gameObject.SetActive(false);
                    _equipButton.gameObject.SetActive(true);
                    _equippedText.gameObject.SetActive(false);
                    _coinsPrice.gameObject.SetActive(false);
                    _crystalsPrice.gameObject.SetActive(false);
                    break;
                case SlotState.Equipped:
                    _buyButton.gameObject.SetActive(false);
                    _equipButton.gameObject.SetActive(false);
                    _equippedText.gameObject.SetActive(true);
                    _coinsPrice.gameObject.SetActive(false);
                    _crystalsPrice.gameObject.SetActive(false);
                    break;
            }
        }
        
        private void Awake()
        {
            var skin = SkinLoader.LoadSkin(SkinDictionary.GetSkinId(_skinType));
            _skinName.SetText(SkinNames.GetSkinName(_skinType));
            var instance = Instantiate(skin, transform);
            instance.transform.position = _prefabSpawnPoint.transform.position;
        }
    }
}