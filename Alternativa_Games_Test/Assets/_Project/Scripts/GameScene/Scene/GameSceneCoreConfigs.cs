using _Project.Scripts.GameScene.Configs;
using System;
using UnityEngine;

namespace _Project.Scripts.GameScene.Scene
{
    public interface IGameSceneCoreConfigs 
    { 
        IHeroesConfig Heroes { get; }
    }

    [Serializable]
    public class GameSceneCoreConfigs : IGameSceneCoreConfigs
    {
        public IHeroesConfig Heroes => _heroesConfig;

        [SerializeField] private HeroesConfig _heroesConfig;
    }
}