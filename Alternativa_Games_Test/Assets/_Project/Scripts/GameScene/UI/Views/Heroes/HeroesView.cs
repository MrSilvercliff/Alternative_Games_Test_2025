using _Project.Scripts.GameScene.Scene;
using _Project.Scripts.GameScene.UI.Widgets.Hero;
using _Project.Scripts.Project.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.GameScene.UI.Views.Heroes
{
    public class HeroesView : MonoBehaviour, IInitializable, IFlushable
    {
        [SerializeField] private HeroesScroll _heroesScroll;

        public bool Init()
        {
            InitHeroesScroll();
            return true;
        }

        public bool Flush()
        {
            _heroesScroll.Flush();
            return true;
        }

        private void InitHeroesScroll()
        {
            _heroesScroll.Init();
            var heroesList = GameSceneCore.Instance.Configs.Heroes.HeroDataList;
            _heroesScroll.Setup(heroesList);
        }
    }
}