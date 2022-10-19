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
        public static void SaveCoins(Currency currency)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/coins";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, currency);
            stream.Close();
        }

        public static Currency LoadCoins()
        {
            string path = Application.persistentDataPath + "/coins";

            if (File.Exists(path))
            { 
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                Currency currency = (Currency)formatter.Deserialize(stream);
                stream.Close();
                return currency;
            }
            else
            {
                SaveCoins(new Currency(100));
                return new Currency(100);
            }
        }
        
        public static void SaveCrystals(Currency currency)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/crystals";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, currency);
            stream.Close();
        }

        public static Currency LoadCrystals()
        {
            string path = Application.persistentDataPath + "/crystals";

            if (File.Exists(path))
            { 
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                Currency currency = (Currency)formatter.Deserialize(stream);
                stream.Close();
                return currency;
            }
            else
            {
                SaveCoins(new Currency(10));
                return new Currency(10);
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

        public static void SaveSkinsInfo(SkinsInformation info)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/skins";
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, info);
            stream.Close();
        }

        public static SkinsInformation LoadSkinsInfo()
        {
            string path = Application.persistentDataPath + "/skins";

            if (File.Exists(path))
            { 
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                SkinsInformation info = (SkinsInformation)formatter.Deserialize(stream);
                stream.Close();
                return info;
            }
            else
            {
                var info = new SkinsInformation(new List<SkinType>() { SkinType.Default }, SkinType.Default);
                SaveSkinsInfo(info);
                return info;
            }
        }
    }
}
