using BallFeatures;
using UnityEngine;
using Zenject;


[RequireComponent(typeof(IMovement))]
public class BallView : MonoBehaviour, IInitializable
{
    private IMovement _movement;

    public void Initialize()
    {
        _movement = GetComponent<IMovement>();
    }

    public void MoveLeft()
    {
        _movement.MoveLeft();
    }

    public void MoveRight()
    {
        _movement.MoveRight();
    }

    public void StartMovement()
    {
        _movement.StartMovement();
    }

    public void StopMovement()
    {
        _movement.StopMovement();
    }

    public void Upgrade()
    {
        transform.localScale *= 1.3f;
    }

    public void Downgrade()
    {
        transform.localScale /= 1.3f;
    }

    public void Smash()
    {
        //throw new System.NotImplementedException();
    }
}
