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

        public override bool Init()
        {
            LogUtils.Info(this, $"Init");
            return true;
        }

        public override bool Flush()
        {
            LogUtils.Info(this, $"Flush");
            return true;
        }
    }
}