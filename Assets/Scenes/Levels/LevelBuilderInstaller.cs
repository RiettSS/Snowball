using LevelLoading;
using UnityEngine;
using Zenject;

public class LevelBuilderInstaller : MonoInstaller
{
    [SerializeField] private LevelBuilderView _levelBuilderView;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LevelBuilder>().AsSingle();
        Container.BindInterfacesAndSelfTo<LevelBuilderView>().FromInstance(_levelBuilderView).AsSingle();
        Container.BindInterfacesAndSelfTo<LevelBuilderPresenter>().AsSingle();
    }
}
