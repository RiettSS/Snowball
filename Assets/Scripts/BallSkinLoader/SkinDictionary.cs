using System.Collections.Generic;

namespace BallSkinLoader
{
    public static class SkinDictionary
    {
        public static readonly Dictionary<SkinType, string> Dictionary = new Dictionary<SkinType, string>()
        {
            { SkinType.Default, "DefaultSkin" },
            { SkinType.Magma, "MagmaSkin" },
            { SkinType.Spike, "SpikeSkin" },
        };
    }
}