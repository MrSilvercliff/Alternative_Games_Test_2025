using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.GameScene.Input;
using _Project.Scripts.GameScene.Scene;
using _Project.Scripts.Project.Extensions;
using _Project.Scripts.Project.Interfaces;
using _Project.Scripts.Project.Log;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ZerglingUnityPlugins.Tools.Scripts.Mono;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroesScroll : MonoBehaviour, IInitializable, IFlushable, IMonoUpdatable, IKeyboardInputListener
    {
        public HeroWidget SelectedWidget { get; protected set; }
        public HeroData SelectedWidgetData { get; protected set; }
        public int SelectedIndex { get; protected set; }

        [SerializeField] protected ScrollRect _scrollRect;
        [SerializeField] private VerticalLayoutGroup _scrollContentLayout;
        [SerializeField] private GameObject _raycastBlocker;
        [SerializeField] private float _lerpTMultiplier;

        protected List<HeroWidget> _widgets;
        protected IReadOnlyList<HeroData> _widgetDatas;

        protected float _widgetBasicHeight;

        private Vector2 _startAnchoredPosition;
        private Vector2 _endAnchoredPosition;
        private float _lerpT;

        private int _lastSelectedIndex;

        protected virtual void OnEnable()
        {
            GameCore.Instance.InputController.Subscribe(this);
            GameCore.Instance.MonoUpdater.Subscribe(this);
        }

        protected virtual void OnDisable()
        {
            GameCore.Instance.InputController.UnSubscribe(this);
            GameCore.Instance.MonoUpdater.UnSubscribe(this);
        }

        public bool Init()
        {
            _widgets = new();

            SelectedWidget = null;
            SelectedWidgetData = default;
            SelectedIndex = int.MinValue;

            _startAnchoredPosition = Vector2.zero;
            _endAnchoredPosition = Vector2.zero;
            _lerpT = float.MaxValue;

            return true;
        }

        public bool Flush()
        {
            DespawnWidgets();
            return true;
        }

        public virtual void OnUpdate()
        {
            if (_raycastBlocker.activeInHierarchy)
                return;

            if (_lerpT > 1.0f)
                return;

            var deltaTime = Time.deltaTime;
            _lerpT += deltaTime * _lerpTMultiplier;

            var currentAnchoredPosition = Vector2.Lerp(_startAnchoredPosition, _endAnchoredPosition, _lerpT);
            _scrollRect.content.anchoredPosition = currentAnchoredPosition;
        }

        public void Setup(IReadOnlyList<HeroData> widgetDataList)
        {
            _widgetDatas = widgetDataList;
            SpawnWidgets();
            SelectWidget(0);
        }

        private void SpawnWidgets()
        {
            var heroWidgetPool = GameCore.Instance.HeroWidgetPool;

            for (int i = 0; i < _widgetDatas.Count; i++)
            {
                var heroData = _widgetDatas[i];

                var newWidget = heroWidgetPool.Spawn();
                _widgetBasicHeight = newWidget.RectTransform.rect.height;
                newWidget.WidgetSelectEvent += OnWidgetSelectEvent;
                newWidget.ExpandStartEvent += OnWidgetExpandStartEvent;
                newWidget.ExpandEndEvent += OnWidgetExpandEndEvent;
                newWidget.transform.SetParent(_scrollRect.content);
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
            var heroWidgetPool = GameCore.Instance.HeroWidgetPool;

            for (int i = 0; i < _widgets.Count; i++)
            {
                var widget = _widgets[i];
                widget.WidgetSelectEvent -= OnWidgetSelectEvent;
                widget.ExpandStartEvent -= OnWidgetExpandStartEvent;
                widget.ExpandEndEvent -= OnWidgetExpandEndEvent;
                heroWidgetPool.Despawn(widget);
            }
        }

        public void SelectWidget(HeroWidget widget)
        {
            var lastSelectedWidget = SelectedWidget;

            _lastSelectedIndex = SelectedIndex;
            SelectedWidget = widget;
            SelectedIndex = _widgets.IndexOf(widget);
            SelectedWidgetData = _widgetDatas[SelectedIndex];

            lastSelectedWidget?.SetSelected(false);
            SelectedWidget.SetSelected(true);
            ScrollToSelectedWidget();
        }

        public void SelectWidget(int index)
        {
            var lastSelectedWidget = SelectedWidget;

            _lastSelectedIndex = SelectedIndex;
            SelectedIndex = index;
            SelectedWidget = _widgets[index];
            SelectedWidgetData = _widgetDatas[index];

            lastSelectedWidget?.SetSelected(false);
            SelectedWidget.SetSelected(true);
            ScrollToSelectedWidget();
        }

        public void SelectNextWidget()
        {
            var lastIndex = _widgets.Count - 1;

            if (SelectedIndex >= lastIndex)
                return;

            var newIndex = SelectedIndex + 1;
            SelectWidget(newIndex);
            ScrollToSelectedWidget();
        }

        public void SelectPreviousWidget()
        {
            if (SelectedIndex == 0)
                return;

            var newIndex = SelectedIndex - 1;
            SelectWidget(newIndex);
            ScrollToSelectedWidget();
        }

        private void ScrollToSelectedWidget()
        {
            var widgetAnchorTop = SelectedWidget.AnchorTop;
            var widgetAnchorBottom = SelectedWidget.AnchorBottom;

            var anchorTopPositionInViewport = _scrollRect.viewport.InverseTransformPoint(widgetAnchorTop.position);
            var anchorBottomPositionInViewport = _scrollRect.viewport.InverseTransformPoint(widgetAnchorBottom.position);

            _startAnchoredPosition = _scrollRect.content.anchoredPosition;

            if (SelectedIndex == 0)
            {
                _endAnchoredPosition = Vector2.zero;
                _lerpT = 0.0f;
                return;
            }

            //Debug.LogError($"SelectedIndex = {SelectedIndex} ; _lastSelectedIndex = {_lastSelectedIndex} ; SelectedIndex - _lastSelectedIndex = {SelectedIndex - _lastSelectedIndex}");

            if (SelectedIndex - _lastSelectedIndex >= 0)
            {
                if (_scrollRect.viewport.rect.Contains(anchorBottomPositionInViewport))
                {
                    //LogUtils.Error(this, $"rect contains whole widget");
                    return;
                }

                _lerpT = 0.0f;
                var widgetAnchorBottomInScrollContent = _scrollRect.content.InverseTransformPoint(SelectedWidget.AnchorBottom.position);
                widgetAnchorBottomInScrollContent.y -= _scrollContentLayout.spacing;
                widgetAnchorBottomInScrollContent.y *= -1;
                widgetAnchorBottomInScrollContent.y -= Screen.height;
                _endAnchoredPosition = new Vector2(0, widgetAnchorBottomInScrollContent.y);
            }
            else
            {
                if (_scrollRect.viewport.rect.Contains(anchorTopPositionInViewport))
                {
                    //LogUtils.Error(this, $"rect contains whole widget");
                    return;
                }

                _lerpT = 0.0f;
                var anchoredPositionTop = -(SelectedWidget.RectTransform.anchoredPosition.y + _scrollContentLayout.padding.top);
                _endAnchoredPosition = new Vector2(0, anchoredPositionTop);
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
            _scrollRect.StopMovement();
        }

        private void OnWidgetExpandEndEvent()
        {
            _raycastBlocker.SetActive(false);
            _scrollRect.StopMovement();
            ScrollToSelectedWidget();
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