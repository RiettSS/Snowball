namespace Model.DailyReward
{
    public interface IRewardFactory
    {
        IReward CreateCoinReward(int coins);

        IReward CreateChestReward();
    }
}
