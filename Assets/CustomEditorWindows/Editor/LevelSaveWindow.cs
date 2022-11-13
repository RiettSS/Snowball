using System.Collections.Generic;
using LevelLoading;
using LevelLoading.legacy;
using Model;
using UnityEditor;
using UnityEngine;
using View;
using Level = LevelLoading.Level;

public class LevelSaveWindow : EditorWindow
{
    private LevelBuilderView _levelBuilderView;
    private string _levelName;
    private int _pointsPerLevel;
    private int _maxLevel;

    [MenuItem("Tools/LevelSaver")]
    public static void ShowWindow()
    {
        GetWindow(typeof(LevelSaveWindow));
    }

    private void OnGUI()
    {
        _pointsPerLevel = EditorGUILayout.IntField("Points Per Level", _pointsPerLevel);
        _maxLevel = EditorGUILayout.IntField("Max Level", _maxLevel);
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
        var obstaclesList = FindObjectsOfType<ObstacleView>();
        var obstacleDTOs = new List<ObstacleDTO>();
        foreach (var view in obstaclesList)
        {
            if (view.gameObject.tag == "UIObstacle")
                continue;

            var position = new LevelLoading.Vector3(view.transform.position.x, view.transform.position.y,
                view.transform.position.z);

            var rotation = new LevelLoading.Vector4(view.transform.rotation.x, view.transform.rotation.y,
                view.transform.rotation.z, view.transform.rotation.w);
            
            obstacleDTOs.Add(new ObstacleDTO(position,
                rotation,
                view.Type, view.ScorePerObstacle, view.Level));
        }
        

        var coinList = FindObjectsOfType<CoinView>();

        var coinDTOs = new List<CoinDTO>();
        foreach (var view in coinList)
        {
            coinDTOs.Add(new CoinDTO(new LevelLoading.Vector3(view.transform.position.x, view.transform.position.y, view.transform.position.z),
                new LevelLoading.Vector4(view.transform.rotation.x, view.transform.rotation.y, view.transform.rotation.z, view.transform.rotation.w), 
                view.Cost, SavableObjectType.Coin));
        }

        var finish = FindObjectOfType<FinishView>();
        var finishDTO = new PositionDTO(
            new LevelLoading.Vector3(finish.transform.position.x, finish.transform.position.y,
                finish.transform.position.z),
            new LevelLoading.Vector4(finish.transform.rotation.x, finish.transform.rotation.y,
                finish.transform.rotation.z, finish.transform.rotation.w));

        var roads = new List<PositionDTO>();
        var roadObjects = GameObject.FindGameObjectsWithTag("Road");

        foreach (var road in roadObjects)
        {
            roads.Add(new PositionDTO(
                new LevelLoading.Vector3(road.transform.position.x, road.transform.position.y,
                    road.transform.position.z),
                new LevelLoading.Vector4(road.transform.rotation.x, road.transform.rotation.y,
                    road.transform.rotation.z, road.transform.rotation.w)));
        }
        
        
        var level = new Level(obstacleDTOs, coinDTOs, roads, finishDTO, _pointsPerLevel, _maxLevel);
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

        var roadsParent = new GameObject("Roads");
        foreach (var road in level.Roads)
        {
            editorBuilder.SpawnRoad(road, roadsParent);
        }
        
        editorBuilder.SpawnFinish(level.Finish);
        
        Debug.Log("Level " + _levelName + " loaded successfully");
    }
}
