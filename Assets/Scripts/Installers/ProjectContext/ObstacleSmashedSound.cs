using System;
using System.ComponentModel;
using Signals;
using TMPro;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class ObstacleSmashedSound : IInitializable, IDisposable
{
    private readonly SignalBus _signalBus;
    private readonly GameObject _audioSourceTemplate;
    private AudioSource _audioSource;

    public ObstacleSmashedSound(SignalBus signalBus, GameObject audioSourceTemplate)
    {
        _signalBus = signalBus;
        _audioSourceTemplate = audioSourceTemplate;
    }

    public void Initialize()
    {
        _audioSource = Object.Instantiate(_audioSourceTemplate).GetComponent<AudioSource>();
        _signalBus.DeclareSignal<ObstacleSmashedSignal>();
        _signalBus.Subscribe<ObstacleSmashedSignal>(PlayObstacleSmashSound);
        _signalBus.Subscribe<ObstacleSmashedSignal>(DebugMessage);
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<ObstacleSmashedSignal>(PlayObstacleSmashSound);
        Object.Destroy(_audioSource);
    }

    private void PlayObstacleSmashSound()
    {
        if(_audioSource.isPlaying)
            _audioSource.Stop();
        
        _audioSource.Play();
    }

    private void DebugMessage()
    {
        Debug.Log("AppStartedSignalFired");
    }
}
