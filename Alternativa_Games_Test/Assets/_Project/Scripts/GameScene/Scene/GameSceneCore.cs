using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.GameScene.Input;
using _Project.Scripts.Project.Log;
using _Project.Scripts.Project.Singleton;
using System;
using UnityEngine;

namespace _Project.Scripts.GameScene.Scene
{
    public interface IGameSceneCore
    {
        IGameSceneCoreConfigs Configs { get; }
        IGameSceneCoreObjectPools ObjectPools { get; }
        
        IInputController InputController { get; }
    }

    public class GameSceneCore : DontDestroyMonoBehaviourSingleton<GameSceneCore>, IGameSceneCore
    {
        public IGameSceneCoreConfigs Configs => _configs;
        public IGameSceneCoreObjectPools ObjectPools => _objectPools;

        public IInputController InputController => _inputController;

        [SerializeField] private GameSceneCoreConfigs _configs;
        [SerializeField] private GameSceneCoreObjectPools _objectPools;
        [SerializeField] private InputHandler _inputHandler;

        private InputController _inputController;

        public override bool Init()
        {
            LogUtils.Info(this, $"Init");
            _objectPools.Init();
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