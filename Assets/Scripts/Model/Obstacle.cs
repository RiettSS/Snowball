using System;
using LevelLoading;
using Sound;
using Zenject;

namespace Model
{
    public class Obstacle
    {
        public event Action OnSmash;
        
        public readonly int Level;
        public readonly int Score;

        private CollisionHandler _collisionHandler;
        private SignalBus _signalBus;
        private SoundSystem _soundSystem;
        private SavableObjectType _type;

        public Obstacle(int level, int score, CollisionHandler collisionHandler, SignalBus signalBus,
            SoundSystem soundSystem,
            SavableObjectType objectType = SavableObjectType.Tree)
        {
            Level = level;
            Score = score;
            _collisionHandler = collisionHandler;
            _signalBus = signalBus;
            _soundSystem = soundSystem;
            _type = objectType;
        }

        public void Collide()
        {
            _collisionHandler.Handle(this);
        }

        public void Smash()
        {
            //_signalBus.Fire<ObstacleSmashedSignal>();
            _soundSystem.PlaySound(_type);
            OnSmash?.Invoke();
        }
    }
}
