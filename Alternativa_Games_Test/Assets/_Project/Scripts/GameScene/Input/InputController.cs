using _Project.Scripts.GameScene.Input;
using _Project.Scripts.Project.Interfaces;
using _Project.Scripts.Project.Singleton;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Scripts.GameScene.Input
{
    public interface IInputController : IInitializable, IFlushable, IKeyboardInputListener
    {
        void Subscribe(IKeyboardInputListener listener);
        void UnSubscribe(IKeyboardInputListener listener);
    }

    public class InputController : IInputController
    {
        public List<IKeyboardInputListener> _keyboardInputListeners;

        public InputController()
        {
            _keyboardInputListeners = new();
        }

        public bool Init()
        {
            return true;
        }

        public bool Flush()
        {
            return true;
        }

        #region Subscribes

        public void Subscribe(IKeyboardInputListener listener)
        {
            if (_keyboardInputListeners.Contains(listener))
                return;

            _keyboardInputListeners.Add(listener);
        }

        public void UnSubscribe(IKeyboardInputListener listener)
        {
            _keyboardInputListeners.Remove(listener);
        }

        #endregion Subscribes



        #region KeyboardInputListener

        public void OnUpArrowClicked()
        {
            for (int i = 0; i < _keyboardInputListeners.Count; i++) 
                _keyboardInputListeners[i].OnUpArrowClicked();
        }

        public void OnDownArrowClicked()
        {
            for (int i = 0; i < _keyboardInputListeners.Count; i++)
                _keyboardInputListeners[i].OnDownArrowClicked();
        }

        public void OnEnterClicked()
        {
            for (int i = 0; i < _keyboardInputListeners.Count; i++)
                _keyboardInputListeners[i].OnEnterClicked();
        }

        #endregion KeyboardInputListener
    }
}
