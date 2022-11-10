namespace LevelLoading
{
    public class LevelProvider : ILevelProvider
    {
        public Level GetLevel(string levelName)
        {
            return new Level();
        }
    }
}