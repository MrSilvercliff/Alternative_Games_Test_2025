using _Project.Scripts.Project.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect
{
    public abstract class ScrollRectWithSelect : MonoBehaviour
    {
        public abstract void SelectNextWidget();
        public abstract void SelectPreviousWidget();
        public abstract void InvokeWidgetInteract();
    }

    public abstract class ScrollRectWithSelect<TWidgetData, TSelectableWidget> : ScrollRectWithSelect, IInitializable, IFlushable where TSelectableWidget : SelectableWidget
    {
        public TSelectableWidget SelectedWidget { get; protected set; }
        public TWidgetData SelectedWidgetData { get; protected set; }
        public int SelectedIndex { get; protected set; }

        protected Transform ScrollRectContent => _scrollRect.content;

        protected List<TSelectableWidget> _widgets;
        protected IReadOnlyList<TWidgetData> _widgetDatas;

        [SerializeField] private ScrollRect _scrollRect;

        public bool Init()
        {
            _widgets = new();

            SelectedWidget = null;
            SelectedWidgetData = default;
            SelectedIndex = int.MinValue;

            var result = OnInit();
            return result;
        }

        protected abstract bool OnInit();

        public bool Flush()
        {
            var result = OnFlush();
            return result;
        }

        protected abstract bool OnFlush();

        public void Setup(IReadOnlyList<TWidgetData> widgetDataList)
        { 
            _widgetDatas = widgetDataList;
            OnSetup();
            SelectWidget(0);
        }

        protected abstract void OnSetup();

        public void SelectWidget(TSelectableWidget widget)
        {
            var lastSelectedWidget = SelectedWidget;

            SelectedWidget = widget;
            SelectedIndex = _widgets.IndexOf(widget);
            SelectedWidgetData = _widgetDatas[SelectedIndex];

            lastSelectedWidget?.SetSelected(false);
            SelectedWidget.SetSelected(true);
        }

        public void SelectWidget(int index)
        {
            var lastSelectedWidget = SelectedWidget;

            SelectedIndex = index;
            SelectedWidget = _widgets[index];
            SelectedWidgetData = _widgetDatas[index];

            lastSelectedWidget?.SetSelected(false);
            SelectedWidget.SetSelected(true);
        }

        public override void SelectNextWidget()
        {
            var lastIndex = _widgets.Count - 1;

            if (SelectedIndex >= lastIndex)
                return;

            var newIndex = SelectedIndex + 1;
            SelectWidget(newIndex);
        }

        public override void SelectPreviousWidget()
        {
            if (SelectedIndex == 0)
                return;

            var newIndex = SelectedIndex - 1;
            SelectWidget(newIndex);
        }

        public override void InvokeWidgetInteract()
        {
            SelectedWidget.Interact();
        }
    }
}