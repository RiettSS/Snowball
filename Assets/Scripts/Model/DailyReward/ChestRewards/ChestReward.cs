namespace Model.DailyReward.ChestRewards
{
    public  class ChestReward : Reward
    {
        private Wallet _wallet;
        
        public ChestReward(Wallet wallet)
        {
            _wallet = wallet;
        }
        
        public override void Apply()
        {
            base.Apply();
        }
    }
}