using UnityEngine;

namespace _Project.Scripts.GameScene.Scene
{
    public class GameSceneController : MonoBehaviour
    {
        private void Awake()
        {
            
        }

        private void Start()
        {
            GameSceneCore.Instance.Init();
        }

        private void OnDestroy()
        {
            GameSceneCore.Instance.Flush();
        }
    }
}