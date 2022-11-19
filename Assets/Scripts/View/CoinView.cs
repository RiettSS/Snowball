using System.Collections;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(AudioSource))]
    public class CoinView : CollidableView
    {
        [SerializeField] public int Cost;
        [SerializeField] private GameObject CoinModel;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Release()
        {
            StartCoroutine(DestroyCoin());
        }
        
        private void PlayCollectionSound()
        {
            _audioSource.Play();
        }

        private IEnumerator DestroyCoin()
        {
            PlayCollectionSound();
            CoinModel.SetActive(false);
            yield return new WaitForSeconds(1);
            gameObject.SetActive(false);
        }
    }
}
