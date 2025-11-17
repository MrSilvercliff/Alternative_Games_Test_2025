using _Project.Scripts.GameScene.Scene;
using _Project.Scripts.GameScene.UI.Widgets.Hero;
using _Project.Scripts.Project.UI.Views;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.GameScene.UI.Views.Heroes
{
    public class HeroesView : View
    {
        [SerializeField] private HeroesScroll _heroesScroll;

        protected override bool OnInit()
        {
            InitHeroesScroll();
            return true;
        }

        protected override bool OnFlush()
        {
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