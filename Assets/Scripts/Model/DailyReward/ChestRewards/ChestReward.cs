using Model.DailyReward.ChestRewards.ChestScreen;

namespace Model.DailyReward.ChestRewards
{
    public  class ChestReward : Reward
    {
        private readonly PrizeMachine _prizeMachine;
        
        public ChestReward(PrizeMachine prizeMachine)
        {
            _prizeMachine = prizeMachine;
        }
        
        public override void Apply()
        {
            base.Apply();
            _prizeMachine.Show();
        }
    }
}