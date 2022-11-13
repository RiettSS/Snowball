using System;

namespace Model
{
    public sealed class Ball
    {
        public event Action OnControlEnabled;
        public event Action OnControlDisabled;
        public event Action OnMovementStarted;
        public event Action OnMovementStopped;
        public event Action OnMoveLeft;
        public event Action OnMoveRight;
        public event Action OnUpgrade;
        public event Action OnDownGrade;
        public event Action OnSmashed;

        public int Level => _level.Value;
        public int MaxLevel => _level.MaxValue;
        private Level _level;
        private Tutorial _tutorial;

        public Ball(int maxLevel)
        {
            _level = new Level(1, maxLevel);
        }

        public void ChangeLevel(Level level)
        {
            _level = level;
        }
        
        public void StartMovement()
        {
            OnMovementStarted?.Invoke();
        }

        public void StopMovement()
        {
            OnMovementStopped?.Invoke();
        }

        public void EnableControl()
        {
            OnControlEnabled?.Invoke();
        }

        public void DisableControl()
        {
            OnControlDisabled?.Invoke();
        }
        
        public void MoveLeft()
        {
            OnMoveLeft?.Invoke();
        }

        public void MoveRight()
        {
            OnMoveRight?.Invoke();
        }

        public void Upgrade()
        {
            if(_level.Value < _level.MaxValue)
                OnUpgrade?.Invoke();
            
            _level = _level.Increase();
        }

        public void Downgrade()
        {
            if(_level.Value > _level.MinValue)
                OnDownGrade?.Invoke();
            
            _level = _level.Decrease();
        }

        public void Smash()
        {
            OnSmashed?.Invoke();
        }
    }
}
