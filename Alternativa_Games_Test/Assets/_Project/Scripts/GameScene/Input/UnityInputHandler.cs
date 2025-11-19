using _Project.Scripts.GameScene.Scene;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.GameScene.Input
{
    public class UnityInputHandler : InputHandler, IInputHandler
    {
        public override bool OnInit()
        {
            return true;
        }

        public override bool Flush()
        {
            return true;
        }

        public void OnUpArrowInputAction(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed)
                return;

            GameCore.Instance.InputController.OnUpArrowClicked();
        }

        public void OnDownArrowInputAction(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed)
                return;

            GameCore.Instance.InputController.OnDownArrowClicked();
        }

        public void OnEnterInputAction(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed)
                return;

            GameCore.Instance.InputController.OnEnterClicked();
        }
    }
}