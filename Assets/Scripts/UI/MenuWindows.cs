using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MenuWindows : MonoBehaviour
{
    [SerializeField] private GameObject _dailyRewardWindow;
    [SerializeField] private GameObject _mainMenuWindow;

    private bool _rewardsWindowSeenToday;
    
    private void Start()
    {
        var lastRewardDate = LoadDate();
        if (lastRewardDate.Equals(DateTime.Today))
        {
            ShowMenu();
        }
        else
        {
            ShowRewards();
            SaveDate(DateTime.Today);
        }
    }


    private void ShowMenu()
    {
        _dailyRewardWindow.SetActive(false);
        _mainMenuWindow.SetActive(true);
    }

    private void ShowRewards()
    {
        _dailyRewardWindow.SetActive(true);
        _mainMenuWindow.SetActive(false);
    }
    
    private void SaveDate(DateTime date)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/dailyRewardMenuSeenToday";
        FileStream stream = new FileStream(path, FileMode.Create);
            
        formatter.Serialize(stream, date);
        stream.Close();
    }
    
    private DateTime LoadDate()
    {
        string path = Application.persistentDataPath + "/dailyRewardMenuSeenToday";

        if (File.Exists(path))
        { 
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DateTime date = (DateTime)formatter.Deserialize(stream);
            stream.Close();
            return date;
        }
        else
        {
            return new DateTime();
        }
    }
}
