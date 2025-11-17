using _Project.Scripts.Project.Interfaces;
using _Project.Scripts.Project.Singleton;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.GameScene.Input
{
    public interface IInputController : IInitializable, IFlushable
    {
    }

    public class InputController : IInputController
    {
        public InputController()
        {
        }

        public bool Init()
        {
            return true;
        }

        public bool Flush()
        {
            return true;
        }
    }
}
