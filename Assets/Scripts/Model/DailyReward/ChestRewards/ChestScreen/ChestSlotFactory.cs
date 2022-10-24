using UI;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class ChestSlotFactory
    {
        private ChestSlotViewFactory _viewFactory;
        
        public ChestSlotFactory(ChestSlotViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }
        
        public Slot CreateCoinsSlot(int amount)
        {
            var currency = new Currency(amount);
            var slot = new Slot(currency, CurrencyType.Coins);
            var view = _viewFactory.CreateCoinsChest();
            var presenter = new SlotPresenter(slot, view);
            presenter.Initialize();

            return slot;
        }

        public Slot CreateCrystalsSlot(int amount)
        {
            var currency = new Currency(amount);
            var slot = new Slot(currency, CurrencyType.Crystals);
            var view = _viewFactory.CreateCrystalsChest();
            var presenter = new SlotPresenter(slot, view);
            presenter.Initialize();
            
            return slot;
        }
    }
}