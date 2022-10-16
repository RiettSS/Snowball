using System.Collections.Generic;

namespace Store
{
    public interface IStoreSlotProvider
    {
        List<StoreSlot> GetSlots();
    }
}