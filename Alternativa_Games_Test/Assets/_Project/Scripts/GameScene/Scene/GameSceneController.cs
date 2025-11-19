using _Project.Scripts.GameScene.UI.Views.Heroes;
using _Project.Scripts.Project.Core;
using UnityEngine;

namespace _Project.Scripts.GameScene.Scene
{
    public class GameSceneController : MonoBehaviour
    {
        [SerializeField] private HeroesView _heroesView;

        private void Awake()
        {
        }

        private void Start()
        {
            ProjectCore.Instance.Init();
            GameSceneCore.Instance.Init();

            _heroesView.Init();
            _heroesView.Open();
        }

        private void OnDestroy()
        {
            _heroesView.Flush();

            GameSceneCore.Instance.Flush();
            ProjectCore.Instance.Flush();
        }
    }
}