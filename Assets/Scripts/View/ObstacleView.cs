﻿using System.Collections;
using LevelLoading;
using UnityEngine;

namespace View
{
    public class ObstacleView : CollidableView
    {
        [SerializeField] public SavableObjectType Type;
        [SerializeField] public int ScorePerObstacle;
        [SerializeField] public int Level;
        [SerializeField] private GameObject _3dModel;
        [SerializeField] private GameObject _slicedPrefab;
        
        public void Smash()
        {
            Instantiate(_slicedPrefab, _3dModel.transform.position, _3dModel.transform.rotation, transform);
            Destroy(_3dModel);
            StartCoroutine(OnSmash());
        }

        public override int GetSaveModel()
        {
            return 2;
        }

        private IEnumerator OnSmash()
        {
            yield return new WaitForSeconds(2);
            gameObject.SetActive(false);
        }
    }
}
