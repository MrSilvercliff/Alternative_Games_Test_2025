using _Project.Scripts.GameScene.Input;
using _Project.Scripts.Project.Core;
using UnityEngine;

namespace _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect
{
    public class ScrollRectWithSelectKeyboardListener : MonoBehaviour, IKeyboardInputListener
    {
        [SerializeField] private ScrollRectWithSelect _scrollRectWithSelect;

        private void OnEnable()
        {
            ProjectCore.Instance.InputController.Subscribe(this);
        }

        private void OnDisable()
        {
            ProjectCore.Instance.InputController.UnSubscribe(this);
        }

        public void OnUpArrowClicked()
        {
            _scrollRectWithSelect.SelectPreviousWidget();
        }

        public void OnDownArrowClicked()
        {
            _scrollRectWithSelect.SelectNextWidget();
        }

        public void OnEnterClicked()
        {
        }
    }
}