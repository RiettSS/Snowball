using Model;

namespace BallSkinLoader
{
    public class SkinsInformationProvider : ISkinsInformationProvider
    {
        public SkinsInformation GetInformation()
        {
            return SaveLoadSystem.LoadSkinsInfo();
        }
    }
}