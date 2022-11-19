using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            var creationCommands = new List<CreateSlotCommand>();

            creationCommands.Add(new CreateCoinsSlotCommand(_slotFactory, 50));
            creationCommands.Add(new CreateCoinsSlotCommand(_slotFactory, 50));
            creationCommands.Add(new CreateCoinsSlotCommand(_slotFactory, 50));
            creationCommands.Add(new CreateCoinsSlotCommand(_slotFactory, 500));
            creationCommands.Add(new CreateCoinsSlotCommand(_slotFactory, 500));
            creationCommands.Add(new CreateCoinsSlotCommand(_slotFactory, 500));
            creationCommands.Add(new CreateCrystalsSlotCommand(_slotFactory, 10));
            creationCommands.Add(new CreateCrystalsSlotCommand(_slotFactory, 10));
            creationCommands.Add(new CreateCrystalsSlotCommand(_slotFactory, 10));
            creationCommands.Add(new CreateCrystalsSlotCommand(_slotFactory, 10));

            var nums = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            nums.Shuffle();

            var slots = new List<Slot>();
            
            foreach (var num in nums)
            {
                slots.Add(creationCommands[num].CreateSlot());
            }

            return slots;
        }
    }

    public abstract class CreateSlotCommand
    {
        protected ChestSlotFactory _factory;
        protected int _amount;

        protected CreateSlotCommand(ChestSlotFactory factory, int amount)
        {
            _factory = factory;
            _amount = amount;
        }

        public abstract Slot CreateSlot();
    }

    public class CreateCoinsSlotCommand : CreateSlotCommand
    {
        public CreateCoinsSlotCommand(ChestSlotFactory factory, int amount) : base(factory, amount)
        {
        }

        public override Slot CreateSlot()
        {
            return _factory.CreateCoinsSlot(_amount);
        }
    }
    
    public class CreateCrystalsSlotCommand : CreateSlotCommand
    {
        public CreateCrystalsSlotCommand(ChestSlotFactory factory, int amount) : base(factory, amount)
        {
        }

        public override Slot CreateSlot()
        {
            return _factory.CreateCrystalsSlot(_amount);
        }
    }
}