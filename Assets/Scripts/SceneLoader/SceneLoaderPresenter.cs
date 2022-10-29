
using System;
using Zenject;

namespace SceneLoader
{
    public class SceneLoaderPresenter : IInitializable, IDisposable
    {
        private SceneLoader _sceneLoader;
        private SceneLoaderView _view;

        public SceneLoaderPresenter(SceneLoader sceneLoader, SceneLoaderView view)
        {
            _sceneLoader = sceneLoader;
            _view = view;
        }
        
        public void Initialize()
        {
            _sceneLoader.LoadingStarted += _view.OnLoadingStarted;
            _sceneLoader.Loaded += _view.OnLoaded;
        }

        public void Dispose()
        {
            _sceneLoader.LoadingStarted -= _view.OnLoadingStarted;
            _sceneLoader.Loaded -= _view.OnLoaded;
        }
    }
}