using _Project.Scripts.GameScene.Input;
using _Project.Scripts.Project.Singleton;
using UnityEngine;

namespace _Project.Scripts.Project.Core
{
    public interface IProjectCore
    { 
        IInputController InputController { get; }
    }

    public class ProjectCore : DontDestroyMonoBehaviourSingleton<ProjectCore>, IProjectCore
    {
        public IInputController InputController => _inputController;

        [SerializeField] private InputHandler _inputHandler;

        private InputController _inputController;

        public override bool Init()
        {
            InitInput();
            return true;
        }

        public override bool Flush()
        {
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