using System;
using UnityEngine;
using Zenject;

namespace SceneLoading
{
    public class SceneLoaderPresenter : IInitializable
    {
        private readonly SceneLoader _sceneLoader;
        private readonly SceneLoaderView _view;

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
    }
}