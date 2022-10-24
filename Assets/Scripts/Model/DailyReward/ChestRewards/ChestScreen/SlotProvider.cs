using System.Collections.Generic;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public class SlotProvider : ISlotProvider
    {
        private ChestSlotFactory _slotFactory;

        public SlotProvider(ChestSlotFactory slotFactory)
        {
            _slotFactory = slotFactory;
        }
        
        public List<Slot> GetSlots()
        {
            var slots = new List<Slot>();
            
            slots.Add(_slotFactory.CreateCoinsSlot(50));
            slots.Add(_slotFactory.CreateCoinsSlot(50));
            slots.Add(_slotFactory.CreateCoinsSlot(50));
            slots.Add(_slotFactory.CreateCrystalsSlot(5));
            slots.Add(_slotFactory.CreateCrystalsSlot(5));
            slots.Add(_slotFactory.CreateCrystalsSlot(5));
            slots.Add(_slotFactory.CreateCoinsSlot(400));
            slots.Add(_slotFactory.CreateCoinsSlot(400));
            slots.Add(_slotFactory.CreateCoinsSlot(400));

            return slots;
        }
    }
}