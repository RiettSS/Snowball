namespace Model
{
    public struct Level
    {
        public readonly int Value;
        public readonly int MaxValue;
        public readonly int MinValue;

        public Level(int level, int maxLevel)
        {
            Value = level;
            MaxValue = maxLevel;
            MinValue = 1;
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
