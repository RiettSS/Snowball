using System;
using System.Collections.Generic;

namespace BallSkinLoader
{
    [Serializable]
    public struct SkinsInformation
    {
        public readonly List<SkinType> Skins;
        public SkinType CurrentSkin { get; private set; }
        
        public SkinsInformation(List<SkinType> skins, SkinType currentSkin)
        {
            Skins = skins;
            CurrentSkin = currentSkin;
        }

        public void AddSkin(SkinType type)
        {
            Skins.Add(type);
        }

        public void RemoveSkin(SkinType type)
        {
            Skins.Remove(type);
        }

        public void SetSkin(SkinType type)
        {
            CurrentSkin = type;
        }
    }
}