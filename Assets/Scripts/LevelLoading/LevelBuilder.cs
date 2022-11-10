using System;

namespace LevelLoading
{
    public class LevelBuilder
    {
        public event Action<string> OnBuildLevel;
        
        public void BuildLevel(string levelName)
        {
            OnBuildLevel?.Invoke(levelName);
        }
    }
}