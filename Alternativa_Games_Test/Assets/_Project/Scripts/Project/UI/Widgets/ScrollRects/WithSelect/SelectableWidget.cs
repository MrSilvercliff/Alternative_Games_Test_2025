using System;
using UnityEngine;

namespace _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect
{
    public interface ISelectableWidget
    {
        void SetSelected(bool selected);
    }

    public interface ISelectableWidget<TWidgetType> where TWidgetType : ISelectableWidget
    {
        void SetSelected(bool selected);
        event Action<TWidgetType> WidgetSelectEvent;
    }

    public abstract class SelectableWidget : UIWidget, ISelectableWidget
    {
        public abstract void SetSelected(bool selected);
    }

    public abstract class SelectableWidget<TWidgetType> : SelectableWidget, ISelectableWidget<TWidgetType> where TWidgetType : SelectableWidget
    {
        public event Action<TWidgetType> WidgetSelectEvent;

        protected void InvokeSelectEvent(TWidgetType widget)
        {
            WidgetSelectEvent?.Invoke(widget);
        }
    }

    public abstract class SelectableWidget<TWidgetType, TWidgetData, TViewType> : SelectableWidget<TWidgetType> 
        where TWidgetType : SelectableWidget
        where TViewType : SelectableWidgetView<TWidgetData>
    {
        [SerializeField] protected TViewType _view;

        protected TWidgetData _data;

        public override void SetSelected(bool selected)
        {
            _view.SetSelected(selected);
        }

        public void Setup(TWidgetData data)
        {
            _data = data;
            _view.Refresh(data);
        }
    }
}