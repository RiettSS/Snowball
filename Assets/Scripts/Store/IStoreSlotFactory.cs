using BallSkinLoader;

namespace Store
{
    public interface IStoreSlotFactory
    {
        StoreSlot CreateStoreSlot(SkinType skinType);
    }
}