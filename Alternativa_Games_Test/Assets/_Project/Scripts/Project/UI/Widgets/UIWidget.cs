using UnityEngine;

namespace _Project.Scripts.Project.UI.Widgets
{
    public class UIWidget : MonoBehaviour
    {
        public RectTransform RectTransform => _rectTransform;

        [SerializeField] private RectTransform _rectTransform;
    }
}