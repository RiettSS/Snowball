using System;
using System.Collections.Generic;
using Sound;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Config", menuName = "Sound Config")]
public class SoundConfig : ScriptableObject
{
    public List<Sound> Sounds;

    [Serializable]
    public class Sound
    {
        public SoundType SoundType;
        public List<AudioClip> Clips;
    }
}

