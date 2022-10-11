using System;

namespace Model.DailyReward
{
    public interface IReward
    {
        public event Action Activated;
        public event Action Deactivated;
        public event Action Today;
        public event Action Applied;
         
        void Apply();

        void SetActive();

        void SetInactive();
    }
}
