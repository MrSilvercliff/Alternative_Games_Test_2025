using UnityEngine;

namespace _Project.Scripts.GameScene.Input
{
    public interface IKeyboardInputListener
    {
        void OnUpArrowClicked();
        void OnDownArrowClicked();
        void OnEnterClicked();
    }
}