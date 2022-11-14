using LevelLoading;
using UnityEngine;
using Zenject;

public class LevelBuilderInstaller : MonoInstaller
{
    [SerializeField] private GameObject _uiObstaclesParent;
    
    public override void InstallBindings()
    { 
        Container.BindInterfacesAndSelfTo<LevelBuilder>().AsSingle().WithArguments(_uiObstaclesParent.transform).NonLazy();
    }
}
