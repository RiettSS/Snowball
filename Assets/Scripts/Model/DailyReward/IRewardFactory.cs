namespace Model.DailyReward
{
    public interface IRewardFactory
    {
        Reward CreateCoinReward(int coins);
        Reward CreateCrystalReward(int crystals);

        Reward CreateChestReward();
    }
}
