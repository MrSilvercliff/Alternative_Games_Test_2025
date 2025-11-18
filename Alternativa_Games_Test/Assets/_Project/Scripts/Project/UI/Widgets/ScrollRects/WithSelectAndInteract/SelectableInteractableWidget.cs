using _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect;
using UnityEngine;

namespace _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelectAndInteract
{
    public interface IInteracrableWidget
    {
        void Interact();
    }

    public abstract class SelectableInteractableWidget : SelectableWidget, IInteracrableWidget
    {
        public abstract void Interact();
    }

    public abstract class SelectableInteractableWidget<TWidgetType, TWidgetData, TViewType> : SelectableWidget<TWidgetType, TWidgetData, TViewType>, IInteracrableWidget
        where TWidgetType : SelectableWidget
        where TViewType : SelectableWidgetView<TWidgetData>
    {
        public abstract void Interact();
    }
}