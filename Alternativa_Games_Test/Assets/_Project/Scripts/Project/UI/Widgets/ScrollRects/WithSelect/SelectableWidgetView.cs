using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect
{
    public abstract class SelectableWidgetView<TWidgetData> : MonoBehaviour
    {
        [Header("SELECTABLE WIDGET VIEW")]
        [SerializeField] private Color _notSelectedColor;
        [SerializeField] private Color _selectedColor;
        [SerializeField] private Image _backImage;

        public void SetSelected(bool selected)
        {
            if (selected)
                _backImage.color = _selectedColor;
            else
                _backImage.color = _notSelectedColor;
        }

        public abstract void Refresh(TWidgetData widgetData);
    }
}