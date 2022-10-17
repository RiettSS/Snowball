using System.Collections.Generic;
using BallSkinLoader;
using UnityEngine;
using Zenject;

namespace Store
{
    public class Store : IInitializable
    {
        private ISkinsInformationProvider _informationProvider;
        private IStoreSlotProvider _slotProvider;
        private SkinsInformation _skinsInformation;
        private List<StoreSlot> _slots;

        public Store(ISkinsInformationProvider informationProvider, IStoreSlotProvider slotProvider)
        {
            _informationProvider = informationProvider;
            _slotProvider = slotProvider;
        }
        
        public void Initialize()
        {
            _slots = _slotProvider.GetSlots();
            _skinsInformation = _informationProvider.GetInformation();
        }
    }
}