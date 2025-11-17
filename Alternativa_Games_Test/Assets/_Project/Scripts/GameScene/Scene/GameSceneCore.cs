using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.Project.Log;
using _Project.Scripts.Project.Singleton;
using System;
using UnityEngine;

namespace _Project.Scripts.GameScene.Scene
{
    public interface IGameSceneCore
    {
        IGameSceneCoreConfigs Configs { get; }
    }

    public class GameSceneCore : DontDestroyMonoBehaviourSingleton<GameSceneCore>, IGameSceneCore
    {
        public IGameSceneCoreConfigs Configs => _configs;

        [SerializeField] private GameSceneCoreConfigs _configs;
        [SerializeField] private GameSceneCoreObjectPools _objectPools;

        public override bool Init()
        {
            LogUtils.Info(this, $"Init");
            _objectPools.Init();
            return true;
        }

        public override bool Flush()
        {
            LogUtils.Info(this, $"Flush");
            return true;
        }
    }
}