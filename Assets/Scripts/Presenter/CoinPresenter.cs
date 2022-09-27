using System;
using Model;
using Unity.VisualScripting.FullSerializer.Internal.Converters;
using View;
using Zenject;

namespace Presenter
{
    public class CoinPresenter: IInitializable, IDisposable
    {
        private Coin _coin;
        private CoinView _coinView;

        public CoinPresenter(Coin coin, CoinView coinView)
        {
            _coin = coin;
            _coinView = coinView;
        }
        
        public void Initialize()
        {
            _coinView.OnCollisionDetected += _coin.Collide;
            _coin.OnRelease += _coinView.Release;
        }

        public void Dispose()
        {
            _coinView.OnCollisionDetected += _coin.Collide;
            _coin.OnRelease -= _coinView.Release;
        }
    }
}
