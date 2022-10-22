namespace Model.DailyReward
{
    public  class ChestReward : Reward
    {
        private Wallet _wallet;
        
        private ChestReward(Wallet wallet)
        {
            _wallet = wallet;
        }
        
        public override void Apply()
        {
            
            base.Apply();
        }

        private void ShowChestReward()
        {
            
        }
    }
}