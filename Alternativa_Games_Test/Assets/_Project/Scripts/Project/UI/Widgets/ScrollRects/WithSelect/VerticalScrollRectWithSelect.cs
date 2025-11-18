using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect
{
    public abstract class VerticalScrollRectWithSelect<TWidgetData, TSelectableWidget> : ScrollRectWithSelect<TWidgetData, TSelectableWidget>
        where TSelectableWidget : SelectableWidget
    {
        [SerializeField] private VerticalLayoutGroup _scrollContentLayout;

        protected float _widgetBasicHeight;

        protected override void OnSelectWidget()
        {
            ScrollToSelectedWidget();
        }

        private void ScrollToSelectedWidget()
        {
            if (SelectedIndex == 0 || SelectedIndex == 1)
            {
                ScrollRectContent.anchoredPosition = Vector2.zero;
                return;
            }

            var anchoredPositionTop = -(SelectedWidget.RectTransform.anchoredPosition.y + _scrollContentLayout.padding.top);
            var offsetToCenter = _widgetBasicHeight + _scrollContentLayout.spacing;
            var anchoredPositionY = anchoredPositionTop - offsetToCenter;
            var anchoredPosition = new Vector2(0, anchoredPositionY);
            ScrollRectContent.anchoredPosition = anchoredPosition;
        }
    }
}