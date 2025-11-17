using _Project.Scripts.GameScene.UI.Views.Heroes;
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
            GameSceneCore.Instance.Init();

            _heroesView.Init();
            _heroesView.Open();
        }

        private void OnDestroy()
        {
            GameSceneCore.Instance.Flush();
        }
    }
}