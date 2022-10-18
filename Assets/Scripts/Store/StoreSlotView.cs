using System;
using System.Runtime.CompilerServices;
using BallSkinLoader;
using SkinDictionaries;
using TMPro;
using UnityEngine;

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

        private GameObject _unlockedModel;
        private GameObject _lockedModel;
        
        private SkinType _skinType;
        private bool _locked;

        public void Construct(SkinType skinType)
        {
            _skinType = skinType;
            var price = SkinPrices.GetPrice(skinType);
            _coinsPrice.SetText(price.Coins.ToString());
            _crystalsPrice.SetText(price.Crystals.ToString());
            
            var skin = SkinLoader.LoadSkin(SkinDictionary.GetSkinId(_skinType));
            _unlockedModel = Instantiate(skin, transform);
            _lockedModel = Instantiate(skin, transform);
            
            ChangeState(SlotState.Buyable);
        }

        public void Buy()
        {
            BuyButtonPressed?.Invoke();
        }

        public void Equip()
        {
            EquipButtonPressed?.Invoke();
        }

        public void SetLockState(bool state)
        {
            _locked = state;
        }

        public void ChangeState(SlotState state)
        {
            if (_buyButton == null)
                return;
            
            switch (state)
            {
                case SlotState.Buyable:
                    _buyButton.gameObject.SetActive(true);
                    _equipButton.gameObject.SetActive(false);
                    _equippedText.gameObject.SetActive(false);
                    _coinsPrice.gameObject.SetActive(true);
                    _crystalsPrice.gameObject.SetActive(true);
                    Lock();
                    break;
                case SlotState.Equipable:
                    _buyButton.gameObject.SetActive(false);
                    _equipButton.gameObject.SetActive(true);
                    _equippedText.gameObject.SetActive(false);
                    _coinsPrice.gameObject.SetActive(false);
                    _crystalsPrice.gameObject.SetActive(false);
                    Unlock();
                    break;
                case SlotState.Equipped:
                    _buyButton.gameObject.SetActive(false);
                    _equipButton.gameObject.SetActive(false);
                    _equippedText.gameObject.SetActive(true);
                    _coinsPrice.gameObject.SetActive(false);
                    _crystalsPrice.gameObject.SetActive(false);
                    Unlock();
                    break;
            }
        }
        
        private void Awake()
        {
            _skinName.SetText(SkinNames.GetSkinName(_skinType));
            
            ChangeMaterial(_lockedModel);
            _unlockedModel.transform.position = _prefabSpawnPoint.transform.position;
            _lockedModel.transform.position = _prefabSpawnPoint.transform.position;
            
            if(_locked)
                Lock();
            else
                Unlock();
        }

        private void ChangeMaterial(GameObject lockedModel)
        {
            var lockedShader = Resources.Load<Shader>("Materials/Black");
            var materials = lockedModel.GetComponentInChildren<MeshRenderer>().materials;
            
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].shader = lockedShader;
            }
        }

        private void Lock()
        {
            _unlockedModel.SetActive(false);
            _lockedModel.SetActive(true);
        }

        private void Unlock()
        {
            _unlockedModel.SetActive(true);
            _lockedModel.SetActive(false);
        }
    }
}