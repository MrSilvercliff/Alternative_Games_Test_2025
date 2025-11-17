using UnityEngine;

namespace _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect
{
    public class SelectableWidget<TViewType> : MonoBehaviour where TViewType : SelectableWidgetView
    {
        [SerializeField] protected TViewType _view;

        public void SetSelected(bool selected)
        {
            _view.SetSelected(selected);
        }
    }
}