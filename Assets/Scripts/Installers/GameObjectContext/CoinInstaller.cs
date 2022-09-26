using System;
using Model;
using Presenter;
using UnityEngine;
using View;
using Zenject;

namespace Installers.GameObjectContext
{
    public class CoinInstaller : MonoInstaller
    {
        [SerializeField] private CoinView _coinView;
        
        public override void InstallBindings()
        {
            Container.Bind<int>().FromInstance(_coinView.Cost).AsSingle();
            Container.BindInterfacesAndSelfTo<Coin>().AsSingle();
            Container.BindInterfacesAndSelfTo<CoinView>().FromInstance(_coinView).AsSingle();
            Container.BindInterfacesAndSelfTo<CoinPresenter>().AsSingle();
        }
    }
}
