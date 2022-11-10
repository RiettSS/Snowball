using System;
using Zenject;

namespace LevelLoading
{
    public class LevelBuilderPresenter : IInitializable, IDisposable
    {
        private LevelBuilder _builder;
        private LevelBuilderView _view;

        public LevelBuilderPresenter(LevelBuilder builder, LevelBuilderView view)
        {
            _builder = builder;
            _view = view;
            _view.BuildLevel("1");
        }
        
        public void Initialize()
        {
            _builder.OnBuildLevel += _view.BuildLevel;
        }

        public void Dispose()
        {
            _builder.OnBuildLevel -= _view.BuildLevel;
        }
    }
}