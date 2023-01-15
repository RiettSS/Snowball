using UnityEngine;
using Zenject;

namespace Sound
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private SoundType _musicType;
        [SerializeField] [Range(0, 1)] private float _volume;
        
        private SoundSystem _soundSystem;
        private AudioSource _musicSource;

        [Inject]
        private void Construct(SoundSystem soundSystem)
        {
            _soundSystem = soundSystem;
        }

        private void Start()
        {
            PlayMusic();
        }

        private void PlayMusic()
        {
            _musicSource = _soundSystem.PlayLooped(_musicType);
            _musicSource.volume = 0.3f;
        }

        private void StopMusic()
        {
            _musicSource.Stop();
        }
        
        private void OnDestroy()
        {
            StopMusic();
        }
    }
}