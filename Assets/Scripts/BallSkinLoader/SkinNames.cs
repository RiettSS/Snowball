using System.Collections.Generic;

namespace BallSkinLoader
{
    public static class SkinNames
    {
        private static readonly Dictionary<SkinType, string> _dictionary = new()
        {
            { SkinType.Default, "Default" },
            { SkinType.Magma, "Magma" },
            { SkinType.Spike, "Spike" },
        };

        public static string GetSkinName(SkinType type)
        {
            return _dictionary[type];
        }
    }
}