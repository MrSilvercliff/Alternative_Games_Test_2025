using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.GameScene.Scene;
using _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect;
using System;
using UnityEngine;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroesScroll : ScrollRectWithSelect<HeroData, HeroWidget>
    {
        protected override bool OnInit()
        {
            return true;
        }

        protected override bool OnFlush()
        {
            DespawnWidgets();
            return true;
        }

        protected override void OnSetup()
        {
            SpawnWidgets();
        }

        private void SpawnWidgets()
        {
            var heroWidgetPool = GameSceneCore.Instance.ObjectPools.HeroWidgetPool;

            for (int i = 0; i < _widgetDatas.Count; i++)
            {
                var heroData = _widgetDatas[i];

                var newWidget = heroWidgetPool.Spawn();
                newWidget.WidgetSelectEvent += OnWidgetSelectEvent;
                newWidget.transform.SetParent(ScrollRectContent);
                newWidget.Setup(heroData);
                newWidget.gameObject.SetActive(true);
                _widgets.Add(newWidget);
            }
        }

        private void DespawnWidgets()
        {
            var heroWidgetPool = GameSceneCore.Instance.ObjectPools.HeroWidgetPool;

            for (int i = 0; i < _widgets.Count; i++)
            { 
                var widget = _widgets[i];
                widget.WidgetSelectEvent -= OnWidgetSelectEvent;
                heroWidgetPool.Despawn(widget);
            }
        }

        private void OnWidgetSelectEvent(HeroWidget widget)
        {
            SelectWidget(widget);
        }
    }
}