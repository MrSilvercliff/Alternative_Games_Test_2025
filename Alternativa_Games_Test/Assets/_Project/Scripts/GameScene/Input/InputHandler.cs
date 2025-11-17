using _Project.Scripts.Project.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.GameScene.Input
{
    public interface IInputHandler : IInitializable, IFlushable
    {
    }

    public abstract class InputHandler : MonoBehaviour, IInputHandler
    {
        public bool Init()
        {
            gameObject.SetActive(true);
            var result = OnInit();
            return result;
        }

        public abstract bool OnInit();

        public abstract bool Flush();
    }
}