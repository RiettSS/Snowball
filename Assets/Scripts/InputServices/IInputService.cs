using System;

namespace InputServices
{
    public interface IInputService
    {
        event Action OnMoveLeft;
        event Action OnMoveRight;
    }
}