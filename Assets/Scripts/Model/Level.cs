using System;

namespace Model
{
    public struct Level
    {
        public readonly int Value;
        public readonly int MaxValue;
        public readonly int MinValue;

        public Level(int level, int maxLevel)
        {
            MaxValue = maxLevel;
            MinValue = 1;

            if (level < MinValue)
            {
                Value = MinValue;
            }
            else if (level > MaxValue)
            {
                Value = MaxValue;
            }
            else
            {
                Value = level;
            }
        }

        public Level Increase()
        {
            if (Value < MaxValue)
                return new Level(Value + 1, MaxValue);
            else 
                return new Level(Value, MaxValue);
        }

        public Level Decrease()
        {
            if (Value > MinValue)
                return new Level(Value - 1, MaxValue);
            else 
                return new Level(Value, MaxValue);
        }
    }
}
