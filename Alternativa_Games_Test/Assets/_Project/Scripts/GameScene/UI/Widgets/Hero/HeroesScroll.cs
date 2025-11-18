using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.GameScene.Input;
using _Project.Scripts.GameScene.Scene;
using _Project.Scripts.Project.Core;
using _Project.Scripts.Project.Extensions;
using _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroesScroll : VerticalScrollRectWithSelect<HeroData, HeroWidget>, IKeyboardInputListener
    {
        [SerializeField] private GameObject _raycastBlocker;
        [SerializeField] private ContentSizeFitter _contentSizeFitter;

        protected override void OnEnable()
        {
            base.OnEnable();
            ProjectCore.Instance.InputController.Subscribe(this);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            ProjectCore.Instance.InputController.UnSubscribe(this);
        }

        protected override bool OnInit()
        {
            _raycastBlocker.SetActive(false);
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

        public override void OnUpdate()
        {
            if (_raycastBlocker.activeInHierarchy)
                return;

            base.OnUpdate();
        }

        private void SpawnWidgets()
        {
            var heroWidgetPool = GameSceneCore.Instance.ObjectPools.HeroWidgetPool;

            for (int i = 0; i < _widgetDatas.Count; i++)
            {
                var heroData = _widgetDatas[i];

                var newWidget = heroWidgetPool.Spawn();
                _widgetBasicHeight = newWidget.RectTransform.rect.height;
                newWidget.WidgetSelectEvent += OnWidgetSelectEvent;
                newWidget.ExpandStartEvent += OnWidgetExpandStartEvent;
                newWidget.ExpandEndEvent += OnWidgetExpandEndEvent;
                newWidget.transform.SetParent(ScrollRectContent);
                newWidget.transform.ResetLocalPosition();
                newWidget.transform.ResetLocalRotation();
                newWidget.transform.ResetLocalScale();
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
                widget.ExpandStartEvent -= OnWidgetExpandStartEvent;
                widget.ExpandEndEvent -= OnWidgetExpandEndEvent;
                heroWidgetPool.Despawn(widget);
            }
        }

        private void OnWidgetSelectEvent(HeroWidget widget)
        {
            _scrollRect.StopMovement();
            SelectWidget(widget);
            EventSystem.current.SetSelectedGameObject(_scrollRect.gameObject);
        }

        private void OnWidgetExpandStartEvent()
        {
            _raycastBlocker.SetActive(true);
            _contentSizeFitter.enabled = false;
            _scrollRect.StopMovement();
        }

        private void OnWidgetExpandEndEvent()
        {
            _raycastBlocker.SetActive(false);
            _contentSizeFitter.enabled = true;
            _scrollRect.StopMovement();
        }

        public void OnUpArrowClicked()
        {
            if (_raycastBlocker.activeInHierarchy)
                return;

            SelectPreviousWidget();
        }

        public void OnDownArrowClicked()
        {
            if (_raycastBlocker.activeInHierarchy)
                return;

            SelectNextWidget();
        }

        public void OnEnterClicked()
        {
            if (_raycastBlocker.activeInHierarchy)
                return;

            SelectedWidget.Interact();
        }
    }
}