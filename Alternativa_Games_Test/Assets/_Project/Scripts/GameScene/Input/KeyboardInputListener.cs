using UnityEngine;

namespace _Project.Scripts.GameScene.Input
{
    public interface KeyboardInputListener
    {
        void OnUpArrowClicked();
        void OnDownArrowClicked();
        void OnEnterClicked();
    }
}