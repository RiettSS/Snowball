using System.Collections;
using UnityEngine;

namespace View
{
    public class ObstacleView : CollidableView
    {
        [SerializeField] private int _scorePerObstacle;
        [SerializeField] private int _level;
        [SerializeField] private GameObject _3dModel;
        [SerializeField] private GameObject _slicedPrefab;
        public int Level => _level;
        public int ScorePerObstacle => _scorePerObstacle;

        public void Smash()
        {
            Instantiate(_slicedPrefab, _3dModel.transform.position, _3dModel.transform.rotation, transform);
            Destroy(_3dModel);
            StartCoroutine(OnSmash());
        }

        private IEnumerator OnSmash()
        {
            yield return new WaitForSeconds(2);
            gameObject.SetActive(false);
        }
    }
}
