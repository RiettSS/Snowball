using System;
using Model;
using Zenject;

namespace InputServices
{
    public class InputEventListener: IInitializable, IDisposable
    {
        private IInputService _inputService;
        private readonly Ball _ball;

        public InputEventListener(IInputService inputService, Ball ball)
        {
            _inputService = inputService;
            _ball = ball;
        }

        public void Initialize()
        {
            Enable();
            
            _ball.OnControlEnabled += Enable;
            _ball.OnControlDisabled += Disable;
        }

        public void Dispose()
        {
            Disable();
            
            _ball.OnControlEnabled -= Enable;
            _ball.OnControlDisabled -= Disable;
        }

        private void Enable()
        {
            _inputService.OnMoveLeft += _ball.MoveLeft;
            _inputService.OnMoveRight += _ball.MoveRight;
        }

        private void Disable()
        {
            _inputService.OnMoveLeft -= _ball.MoveLeft;
            _inputService.OnMoveRight -= _ball.MoveRight;
        }
    }
}
