using _Project.Scripts.Project.Core;
using UnityEngine;
using UnityEngine.UI;
using ZerglingUnityPlugins.Tools.Scripts.Mono;

namespace _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect
{
    public abstract class VerticalScrollRectWithSelect<TWidgetData, TSelectableWidget> : ScrollRectWithSelect<TWidgetData, TSelectableWidget>, IMonoUpdatable
        where TSelectableWidget : SelectableWidget
    {
        [SerializeField] private VerticalLayoutGroup _scrollContentLayout;
        [SerializeField] private float _lerpTMultiplier;

        protected float _widgetBasicHeight;

        private Vector2 _startAnchoredPosition;
        private Vector2 _endAnchoredPosition;
        private float _lerpT;

        protected override bool OnInit()
        {
            _startAnchoredPosition = Vector2.zero;
            _endAnchoredPosition = Vector2.zero;
            _lerpT = float.MaxValue;
            return true;
        }

        protected virtual void OnEnable()
        {
            ProjectCore.Instance.MonoUpdater.Subscribe(this);
        }

        protected virtual void OnDisable()
        {
            ProjectCore.Instance.MonoUpdater.UnSubscribe(this);
        }

        protected override void OnSelectWidget()
        {
            ScrollToSelectedWidget();
        }

        private void ScrollToSelectedWidget()
        {
            _lerpT = 0.0f;
            _startAnchoredPosition = ScrollRectContent.anchoredPosition;

            if (SelectedIndex == 0 || SelectedIndex == 1)
            {
                _endAnchoredPosition = Vector2.zero;
                return;
            }

            var anchoredPositionTop = -(SelectedWidget.RectTransform.anchoredPosition.y + _scrollContentLayout.padding.top);
            var offsetToCenter = _widgetBasicHeight + _scrollContentLayout.spacing;
            var anchoredPositionY = anchoredPositionTop - offsetToCenter;
            var anchoredPosition = new Vector2(0, anchoredPositionY);
            _endAnchoredPosition = anchoredPosition;
        }

        public void OnUpdate()
        {
            if (_lerpT > 1.0f)
                return;

            var deltaTime = Time.deltaTime;
            _lerpT += deltaTime * _lerpTMultiplier;

            var currentAnchoredPosition = Vector2.Lerp(_startAnchoredPosition, _endAnchoredPosition, _lerpT);
            ScrollRectContent.anchoredPosition = currentAnchoredPosition;
        }
    }
}