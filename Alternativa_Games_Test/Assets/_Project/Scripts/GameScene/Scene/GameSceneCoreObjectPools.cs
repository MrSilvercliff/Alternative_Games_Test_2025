using _Project.Scripts.GameScene.ObjectPools;
using _Project.Scripts.Project.Interfaces;
using _Project.Scripts.Project.ObjectPools;
using System;
using UnityEngine;

namespace _Project.Scripts.GameScene.Scene
{
    public interface IGameSceneCoreObjectPools : IInitializable
    {
        HeroWidgetPool HeroWidgetPool { get; }
    }

    [Serializable]
    public class GameSceneCoreObjectPools : IGameSceneCoreObjectPools
    {
        public HeroWidgetPool HeroWidgetPool { get; private set; }

        [SerializeField] private ObjectPoolInitData _heroWidgetPoolInitData;

        public bool Init()
        {
            InitHeroWidgetPool();
            return true;
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