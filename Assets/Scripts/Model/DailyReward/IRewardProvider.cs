namespace Model.DailyReward
{
    public interface IRewardProvider
    {
        IReward GetCoinsReward(int coins);
    }
}
