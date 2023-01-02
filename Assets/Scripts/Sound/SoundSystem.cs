using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Sound
{
    public class SoundSystem : IInitializable
    {
        private SoundConfig _soundConfig;
        private List<AudioSource> _audioSources;
        private GameObject _audioSourcesParent;

        public SoundSystem(SoundConfig soundConfig)
        {
            _soundConfig = soundConfig;
            _audioSourcesParent = new GameObject("AudioSources");
            Object.DontDestroyOnLoad(_audioSourcesParent);
            Debug.Log(_audioSourcesParent.name);
        }

        public void Initialize()
        {
            _audioSources = new List<AudioSource>();
        }
        
        public void PlaySound(SoundType type)
        {
            var clip = FindClip(type);
            var audioSource = FindSource();

            audioSource.clip = clip;
            audioSource.Play();
        }

        private AudioClip FindClip(SoundType type)
        {
            var clip = _soundConfig.Sounds.First(x => x.SoundType == type).Clip;

            if (clip == null)
            {
                Debug.LogError("No such sound in list: " + type);
                return null;
            }

            return clip;
        }

        private AudioSource FindSource()
        {
            AudioSource result;
            
            try
            {
                result = _audioSources.First(x => x.isPlaying == false);
            }
            catch
            {
                var gameObject = new GameObject("AudioSource")
                {
                    transform =
                    {
                        parent = _audioSourcesParent.transform
                    }
                };
                gameObject.AddComponent<AudioSource>();
                result = gameObject.GetComponent<AudioSource>();
                _audioSources.Add(result);
            }
            
            return result;
        }
    }
}