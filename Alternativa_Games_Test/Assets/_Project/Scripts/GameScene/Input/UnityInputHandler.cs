using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

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
    }
}