using System;
using UnityEngine;
using Zenject;

namespace SceneLoading
{
    public class SceneLoaderPresenter : IInitializable
    {
        private readonly LevelLoader _levelLoader;
        private readonly SceneLoaderView _view;

        public SceneLoaderPresenter(LevelLoader levelLoader, SceneLoaderView view)
        {
            _levelLoader = levelLoader;
            _view = view;
        }
        
        public void Initialize()
        {
            _levelLoader.LoadingStarted += _view.OnLoadingStarted;
            _levelLoader.Loaded += _view.OnLoaded;
        }
    }
}