using _Project.Scripts.GameScene.Input;
using _Project.Scripts.Project.Log;
using _Project.Scripts.Project.MonoUpdate;
using _Project.Scripts.Project.Singleton;
using UnityEngine;

namespace _Project.Scripts.Project.Core
{
    public interface IProjectCore
    { 
        IMonoUpdater MonoUpdater { get; }
        IInputController InputController { get; }
    }

    public class ProjectCore : DontDestroyMonoBehaviourSingleton<ProjectCore>, IProjectCore
    {
        public IMonoUpdater MonoUpdater => _monoUpdater;
        public IInputController InputController => _inputController;

        [SerializeField] private MonoUpdater _monoUpdater;
        [SerializeField] private InputHandler _inputHandler;

        private InputController _inputController;

        public override bool Init()
        {
            LogUtils.Info(this, $"Init");
            _monoUpdater.Init();
            InitInput();
            return true;
        }

        public override bool Flush()
        {
            LogUtils.Info(this, $"Flush");
            return true;
        }

        private void InitInput()
        {
            _inputController = new InputController();
            _inputController.Init();
            _inputHandler.Init();
        }
    }
}