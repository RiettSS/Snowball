using UnityEngine;

namespace BallSkinLoader
{
    public static class SkinLoader
    {
        public static GameObject LoadSkin(string fileName)
        {
            return Resources.Load<GameObject>("Skins/" + fileName);
        }
    }
}