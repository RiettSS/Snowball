using System.Collections.Generic;
using BallSkinLoader;

namespace SkinDictionaries
{
    public static class SkinDictionary
    {
        private static readonly Dictionary<SkinType, string> _dictionary = new Dictionary<SkinType, string>()
        {
            { SkinType.Default, "DefaultSkin" },
            { SkinType.Magma, "MagmaSkin" },
            { SkinType.Spike, "SpikeSkin" },
            { SkinType.Thread, "ThreadSkin" },
        };

        public static string GetSkinId(SkinType type)
        {
            return _dictionary[type];
        }
    }
}