using _Project.Scripts.GameScene.Scene;
using _Project.Scripts.GameScene.UI.Widgets.Hero;
using _Project.Scripts.Project.UI.Views;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.GameScene.UI.Views.Heroes
{
    public class HeroesView : View
    {
        [SerializeField] private Transform _heroWidgetContainer;

        private List<HeroWidget> _heroWidgets;

        protected override bool OnInit()
        {
            InitHeroWidgets();
            return true;
        }

        protected override bool OnFlush()
        {
            return true;
        }

        private void InitHeroWidgets()
        {
            _heroWidgets = new();

            var heroesList = GameSceneCore.Instance.Configs.Heroes.HeroDataList;
            var heroWidgetPool = GameSceneCore.Instance.ObjectPools.HeroWidgetPool;

            for (int i = 0; i < heroesList.Count; i++)
            {
                var heroData = heroesList[i];

                var newWidget = heroWidgetPool.Spawn();
                newWidget.transform.SetParent(_heroWidgetContainer);
                newWidget.Setup(heroData);
                newWidget.gameObject.SetActive(true);
                _heroWidgets.Add(newWidget);
            }
        }
    }
}