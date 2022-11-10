namespace LevelLoading
{
    public interface ILevelProvider
    {
        Level GetLevel(string levelName);
    }
}