using System.Collections.Generic;

namespace Model.DailyReward.ChestRewards.ChestScreen
{
    public interface ISlotProvider
    {
        List<Slot> GetSlots();
    }
}