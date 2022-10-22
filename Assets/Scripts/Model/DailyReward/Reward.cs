using System;

namespace Model.DailyReward
{
    public abstract class Reward
    {
        public event Action Activated;
        public event Action Deactivated;
        public event Action Today;
        public event Action Applied;
        public event Action<int> AppliedOnDay;

        public int Day { get; set; }
        
        public virtual void Apply()
        {
            Applied?.Invoke();
            AppliedOnDay?.Invoke(Day);
        }

        public void SetActive()
        {
            Activated?.Invoke();
        }

        public void SetInactive()
        {
            Deactivated?.Invoke();
        }

        public void SetTodayBackground()
        {
            Today?.Invoke();
        }
    }
}