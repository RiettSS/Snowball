using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BallSkinLoader;
using Model.DailyReward;
using UnityEngine;

namespace Model
{
    public static class SaveLoadSystem
    {
        public static void SaveCoins(CoinsAmount amount)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/coins";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, amount);
            stream.Close();
        }

        public static CoinsAmount LoadCoins()
        {
            string path = Application.persistentDataPath + "/coins";

            if (File.Exists(path))
            { 
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                CoinsAmount amount = (CoinsAmount)formatter.Deserialize(stream);
                stream.Close();
                return amount;
            }
            else
            {
                return new CoinsAmount(100);
            }
        }

        public static void SaveRewardInfo(DailyRewardInformation date)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/dailyReward";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, date);
            stream.Close();
        }

        public static DailyRewardInformation LoadRewardInfo()
        {
            string path = Application.persistentDataPath + "/dailyReward";

            if (File.Exists(path))
            { 
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                DailyRewardInformation dateInformation = (DailyRewardInformation)formatter.Deserialize(stream);
                stream.Close();
                return dateInformation;
            }
            else
            {
                var info = new DailyRewardInformation(DateTime.MinValue, 1, new List<int>());
                return info;
            }
        }

        public static void SaveSkinsInfo(PlayerSkinsInformation info)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/skins";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, info);
            stream.Close();
        }

        public static PlayerSkinsInformation LoadSkinsInfo()
        {
            string path = Application.persistentDataPath + "/skins";

            if (File.Exists(path))
            { 
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerSkinsInformation info = (PlayerSkinsInformation)formatter.Deserialize(stream);
                stream.Close();
                return info;
            }
            else
            {
                var info = new PlayerSkinsInformation(new List<SkinType>());
                return info;
            }
        }
    }
}
