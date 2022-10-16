using BallSkinLoader;
using Model;

namespace Store
{
    public class StoreSlotFactory : IStoreSlotFactory
    {
        private readonly StoreSlotViewFactory _viewFactory;
        private readonly SkinStorage _skinStorage;

        public StoreSlotFactory(StoreSlotViewFactory viewFactory, SkinStorage skinStorage)
        {
            _viewFactory = viewFactory;
            _skinStorage = skinStorage;
        }
        
        public StoreSlot CreateStoreSlot(SkinType skinType)
        {
            var view = _viewFactory.GetSkinSlot(skinType);
            if (_skinStorage.IsBought(skinType))
            {
                view.ChangeState(SlotState.Equipable);
            }

            if (_skinStorage.CurrentSkin == skinType)
            {
                view.ChangeState(SlotState.Equipped);
            }
            
            var model = new StoreSlot(skinType, _skinStorage);
            var presenter = new StoreSlotPresenter(model, view);
            presenter.Initialize();

            return model;
        }
    }
}