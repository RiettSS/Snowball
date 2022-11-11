using System;

namespace LevelLoading.legacy
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