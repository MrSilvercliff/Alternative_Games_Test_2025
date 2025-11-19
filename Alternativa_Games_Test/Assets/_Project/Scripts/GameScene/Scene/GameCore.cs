using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.GameScene.Input;
using _Project.Scripts.GameScene.ObjectPools;
using _Project.Scripts.Project.Log;
using _Project.Scripts.Project.MonoUpdate;
using _Project.Scripts.Project.ObjectPools;
using _Project.Scripts.Project.Singleton;
using Assets._Project.Scripts.GameScene.Input;
using System;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

namespace _Project.Scripts.GameScene.Scene
{
    public interface IGameCore
    {
        IMonoUpdater MonoUpdater { get; }
        IInputController InputController { get; }

        IHeroesConfig HeroesConfig { get; }
        HeroWidgetPool HeroWidgetPool { get; }
    }

    public class GameCore : DontDestroyMonoBehaviourSingleton<GameCore>, IGameCore
    {
        public IMonoUpdater MonoUpdater => _monoUpdater;
        public IInputController InputController => _inputController;

        public IHeroesConfig HeroesConfig => _heroesConfig;
        public HeroWidgetPool HeroWidgetPool { get; private set; }

        [SerializeField] private MonoUpdater _monoUpdater;
        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private HeroesConfig _heroesConfig;
        [SerializeField] private ObjectPoolInitData _heroWidgetPoolInitData;

        private InputController _inputController;

        public override bool Init()
        {
            LogUtils.Info(this, $"Init");
            _monoUpdater.Init();
            InitInput();
            InitHeroWidgetPool();
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

        private void InitHeroWidgetPool()
        {
            var prefab = _heroWidgetPoolInitData.Prefab;
            var container = _heroWidgetPoolInitData.Container;
            var initCount = _heroWidgetPoolInitData.InitCount;
            HeroWidgetPool = new HeroWidgetPool(prefab, container, initCount);
        }
    }
}