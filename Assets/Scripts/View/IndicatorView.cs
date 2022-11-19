using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

namespace View
{
    public class IndicatorView : MonoBehaviour, IInitializable
    {
        [SerializeField] private GameObject _obstaclesParent;
        [SerializeField] private TMP_Text _pointsLeftText;
        [SerializeField] private Transform _maxLevelObstaclePosition;

        private List<ObstacleView> _obstacleViews;
        private int _maxLevel;
        private int _minLevel;
        private bool _maxLevelObstacleHasBeenShown;

        public void Initialize()
        {
            var obstacleViews = _obstaclesParent.GetComponentsInChildren<ObstacleView>();
            _obstacleViews = obstacleViews.ToList();
            
            CalculateMinAndMaxLevels();
            HideAllObstacles();
            ShowObstacleWithLevel(_minLevel);
        }

        public void OnPointsLeftChanged(int points)
        {
            _pointsLeftText.text = points.ToString();
        }

        public void OnLevelChanged(int level)
        {
            if (level < _maxLevel)
            {
                ShowObstacleWithLevel(level);
            }

            if (level == _maxLevel)
            {
                if (_maxLevelObstacleHasBeenShown)
                    return;
                
                ShowMaxLevelObstacle();
                HideText();
                _maxLevelObstacleHasBeenShown = true;
            }
        }
        
        private void ShowObstacleWithLevel(int level)
        {
            HideAllObstacles();
            var obstacle = _obstacleViews.FirstOrDefault(x => x.Level == level);
            obstacle.gameObject.SetActive(true);
        }

        private void ShowMaxLevelObstacle()
        {
            HideAllObstacles();
            var obstacle = _obstacleViews.FirstOrDefault(x => x.Level == _maxLevel);
            obstacle.gameObject.SetActive(true);
            var desiredPosition = new Vector3(_maxLevelObstaclePosition.position.x, _maxLevelObstaclePosition.position.y, _maxLevelObstaclePosition.position.z);
            obstacle.transform.position = desiredPosition;
        }

        private void HideAllObstacles()
        {
            foreach (var obstacleView in _obstacleViews)
            {
                obstacleView.gameObject.SetActive(false);
            }
        }

        private void HideText()
        {
            _pointsLeftText.gameObject.SetActive(false);
        }

        private void CalculateMinAndMaxLevels()
        {
            _minLevel = _obstacleViews.Min(x => x.Level);
            _maxLevel = _obstacleViews.Max(x => x.Level);

            foreach (var view in _obstacleViews)
            {
                Debug.Log(view.Type + " level is " + view.Level);
            }
        }
        
        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
