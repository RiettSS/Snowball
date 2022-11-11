using System.Collections.Generic;
using LevelLoading;
using Model;
using UnityEditor;
using UnityEngine;
using View;
using Level = LevelLoading.Level;

public class LevelSaveWindow : EditorWindow
{
    private GameObject _obstaclesParent;
    private GameObject _coinsParent;
    private LevelBuilderView _levelBuilderView;
    private string _levelName;
    
    [MenuItem("Tools/LevelSaver")]
    public static void ShowWindow()
    {
        GetWindow(typeof(LevelSaveWindow));
    }

    private void OnGUI()
    {
        _obstaclesParent = EditorGUILayout.ObjectField("ObstaclesParent", _obstaclesParent, typeof(GameObject), true) as GameObject;
        _coinsParent = EditorGUILayout.ObjectField("CoinsParent", _coinsParent, typeof(GameObject), true) as GameObject;
        _levelName = EditorGUILayout.TextField("LevelName", _levelName);
        
        if (GUILayout.Button("Save Level"))
        {
            SaveLevel();
        }
        
        if (GUILayout.Button("Load Level"))
        {
            LoadLevel();
        }
    }

    private void SaveLevel()
    {
        var obstaclesList = _obstaclesParent.GetComponentsInChildren<ObstacleView>();
        var obstacleDTOs = new List<ObstacleDTO>();
        foreach (var view in obstaclesList)
        {
            var position = new LevelLoading.Vector3(view.transform.position.x, view.transform.position.y,
                view.transform.position.z);

            var rotation = new LevelLoading.Vector4(view.transform.rotation.x, view.transform.rotation.y,
                view.transform.rotation.z, view.transform.rotation.w);
            
            obstacleDTOs.Add(new ObstacleDTO(position,
                rotation,
                view.Type, view.ScorePerObstacle, view.Level));
        }
        
        
        var coinList = _coinsParent.GetComponentsInChildren<CoinView>();

        var coinDTOs = new List<CoinDTO>();
        foreach (var view in coinList)
        {
            coinDTOs.Add(new CoinDTO(new LevelLoading.Vector3(view.transform.position.x, view.transform.position.y, view.transform.position.z),
                new LevelLoading.Vector4(view.transform.rotation.x, view.transform.rotation.y, view.transform.rotation.z, view.transform.rotation.w), 
                view.Cost, SavableObjectType.Coin));
        }

        var level = new Level(obstacleDTOs, coinDTOs);
        SaveLoadSystem.SaveLevel(level, _levelName);
        Debug.Log("Level " + _levelName + " saved successfully");
    }

    private void LoadLevel()
    {
        var level = SaveLoadSystem.LoadLevel(_levelName);
        
        var editorBuilder = new EditorLevelLoader();
        var coinsParent = new GameObject("Coins");
        foreach (var coin in level.Coins)
        {
            editorBuilder.SpawnCoin(coin, coinsParent);
        }

        var obstaclesParent = new GameObject("Obstacles");
        foreach (var obstacle in level.Obstacles)
        {
            editorBuilder.SpawnObstacle(obstacle, obstaclesParent);
        }
        
        Debug.Log("Level " + _levelName + " loaded successfully");
    }
}
