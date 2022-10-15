using System;
using System.Collections.Generic;

namespace BallSkinLoader
{
    [Serializable]
    public struct PlayerSkinsInformation
    {
        public readonly List<SkinType> Skins;

        public PlayerSkinsInformation(List<SkinType> skins)
        {
            Skins = skins;
        }
    }
}