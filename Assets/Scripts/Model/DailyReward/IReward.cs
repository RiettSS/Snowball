using System;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;

namespace Model.DailyReward
{
    public interface IReward
    {
        public event Action Activated;
        public event Action Deactivated;
        public event Action Today;
        public event Action Applied;

        public event Action<int> AppliedOnDay; 
         
        public int Day { get; set; }
        
        void Apply();

        void SetActive();

        void SetInactive();

        void SetTodayBackground();
    }
}
