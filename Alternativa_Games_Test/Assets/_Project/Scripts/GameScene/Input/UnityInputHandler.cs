using _Project.Scripts.GameScene.Scene;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

            Debug.Log("UpArrow");
        }

        public void OnDownArrowInputAction(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed)
                return;

            Debug.Log("DownArrow");
        }

        public void OnEnterInputAction(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Performed)
                return;

            Debug.Log("Enter");
        }
    }
}