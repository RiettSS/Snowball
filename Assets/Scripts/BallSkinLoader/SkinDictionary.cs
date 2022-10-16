using System.Collections.Generic;

namespace BallSkinLoader
{
    public static class SkinDictionary
    {
        private static readonly Dictionary<SkinType, string> _dictionary = new Dictionary<SkinType, string>()
        {
            { SkinType.Default, "DefaultSkin" },
            { SkinType.Magma, "MagmaSkin" },
            { SkinType.Spike, "SpikeSkin" },
        };

        public static string GetSkinId(SkinType type)
        {
            return _dictionary[type];
        }
    }
}