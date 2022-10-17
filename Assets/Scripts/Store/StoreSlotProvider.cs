using System.Collections.Generic;
using BallSkinLoader;

namespace Store
{
    public class StoreSlotProvider : IStoreSlotProvider
    {
        private IStoreSlotFactory _factory;
        
        public StoreSlotProvider(IStoreSlotFactory factory)
        {
            _factory = factory;
        }
        
        public List<StoreSlot> GetSlots()
        {
            var list = new List<StoreSlot>();

            list.Add(_factory.CreateStoreSlot(SkinType.Default));
            list.Add(_factory.CreateStoreSlot(SkinType.Magma));
            list.Add(_factory.CreateStoreSlot(SkinType.Spike));
            list.Add(_factory.CreateStoreSlot(SkinType.Thread));

            return list;
        }
    }
}