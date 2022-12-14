using System.Collections.Generic;
using LevelLoading;
using Model;
using UnityEditor;
using UnityEngine;
using View;
using Level = LevelLoading.Level;

namespace CustomEditorWindows.Editor
{
    public class LevelSaveWindow : EditorWindow
    {
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
            var types = new List<SavableObjectType>();
        
            foreach (var view in obstaclesList)
            {
                if (view.gameObject.tag == "UIObstacle")
                    continue;

                var position = new LevelLoading.Vector3(view.transform.position.x, view.transform.position.y,
                    view.transform.position.z);

                var rotation = new LevelLoading.Vector4(view.transform.rotation.x, view.transform.rotation.y,
                    view.transform.rotation.z, view.transform.rotation.w);

                var scale = new LevelLoading.Vector3(view.transform.localScale.x, view.transform.localScale.y,
                    view.transform.localScale.z);

                obstacleDTOs.Add(new ObstacleDTO(new TransformDTO(view.transform),
                    view.Type, view.ScorePerObstacle, view.Level));

                if (!types.Contains(view.Type) && view.tag != "IndicatorIgnore")
                {
                    types.Add(view.Type);
                }
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
            var finishDTO = new TransformDTO(finish.transform);

            var roads = new List<TransformDTO>();
            var roadObjects = GameObject.FindGameObjectsWithTag("Road");

            foreach (var road in roadObjects)
            {
                roads.Add(new TransformDTO(road.transform));
            }

            var finishBarrier = GameObject.FindGameObjectWithTag("FinishBarrier");
            var barrierDto = new TransformDTO(finishBarrier.transform);
        
            var level = new Level(obstacleDTOs, coinDTOs, roads, finishDTO, barrierDto, _pointsPerLevel, _maxLevel, types);
            SaveLoadSystem.SaveLevel(level, _levelName);
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
            editorBuilder.SpawnFinishBarrier(level.FinishBarrier);
        
            Debug.Log("Level " + _levelName + " loaded successfully");
        }
    }
}
