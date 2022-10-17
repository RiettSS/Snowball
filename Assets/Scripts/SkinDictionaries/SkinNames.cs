using System.Collections.Generic;
using BallSkinLoader;

namespace SkinDictionaries
{
    public static class SkinNames
    {
        private static readonly Dictionary<SkinType, string> _dictionary = new()
        {
            { SkinType.Default, "Default" },
            { SkinType.Magma, "Magma" },
            { SkinType.Spike, "Spike" },
            { SkinType.Thread, "Thread" },
        };

        public static string GetSkinName(SkinType type)
        {
            return _dictionary[type];
        }
    }
}