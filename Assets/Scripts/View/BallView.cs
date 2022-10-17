using BallFeatures;
using BallSkinLoader;
using SkinDictionaries;
using UnityEngine;
using Zenject;


[RequireComponent(typeof(IMovement))]
public class BallView : MonoBehaviour, IInitializable
{
    private IMovement _movement;
    private SkinStorage _storage;
    private GameObject _mesh;

    [Inject]
    public void Construct(SkinStorage skinStorage)
    {
        _storage = skinStorage;
    }
    
    public void Initialize()
    {
        _movement = GetComponent<IMovement>();
        var skin = SkinLoader.LoadSkin(SkinDictionary.GetSkinId(_storage.CurrentSkin));
        _mesh = Instantiate(skin, transform);
        _mesh.transform.localScale /= 100;
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
        _mesh.SetActive(false);
        
    }
}
