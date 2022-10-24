using Model.DailyReward.ChestRewards.ChestScreen;
using UnityEngine;

namespace Model.DailyReward.ChestRewards
{
    public  class ChestReward : Reward
    {
        private Wallet _wallet;
        private PrizeMachine _prizeMachine;
        
        public ChestReward(Wallet wallet, PrizeMachine prizeMachine)
        {
            _wallet = wallet;
            _prizeMachine = prizeMachine;
        }
        
        public override void Apply()
        {
            base.Apply();
            _prizeMachine.Show();
            Debug.Log("CHEST REWARD APPLY");
        }
    }
}