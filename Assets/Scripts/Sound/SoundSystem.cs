using System.Collections.Generic;
using System.Linq;
using LevelLoading;
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
            
            Debug.Log(type.ToString() + " is playing");
            
            audioSource.Play();
        }

        public void PlaySound(SavableObjectType type)
        {
            switch (type)
            {
                case SavableObjectType.Bush:
                    PlaySound(SoundType.Bush);
                    break;
                case SavableObjectType.Tree:
                    PlaySound(SoundType.Tree);
                    break;
                case SavableObjectType.Tent:
                    PlaySound(SoundType.Tent);
                    break;
                case SavableObjectType.Gift:
                    PlaySound(SoundType.Gift);
                    break;
                case SavableObjectType.Snowman:
                    PlaySound(SoundType.Snowman);
                    break;
                case SavableObjectType.Candy:
                    PlaySound(SoundType.Candy);
                    break;
                case SavableObjectType.House:
                    PlaySound(SoundType.House);
                    break;
                case SavableObjectType.Fire:
                    PlaySound(SoundType.Fire);
                    break;
                case SavableObjectType.Coin:
                    PlaySound(SoundType.Coin);
                    break;
                case SavableObjectType.BlueSpike:
                    PlaySound(SoundType.BlueSpike);
                    break;
            }
        }

        public AudioSource PlayLooped(SoundType soundType)
        {
            var audioSource = FindSource();
            var clip = FindClip(soundType);
            
            audioSource.loop = true;
            audioSource.clip = clip;
            audioSource.Play();

            Debug.Log(soundType.ToString() + " is playing");
            
            return audioSource;
        }
        
        private AudioClip FindClip(SoundType type)
        {
            var clips = _soundConfig.Sounds.First(x => x.SoundType == type).Clips;

            var clip = clips[Random.Range(0, clips.Count)];
            
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
                result.loop = false;
                result.volume = 1;
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