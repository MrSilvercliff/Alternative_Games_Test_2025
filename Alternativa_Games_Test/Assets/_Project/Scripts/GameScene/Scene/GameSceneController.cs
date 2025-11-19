using _Project.Scripts.GameScene.UI.Views.Heroes;
using _Project.Scripts.Project.Log;
using UnityEngine;

namespace _Project.Scripts.GameScene.Scene
{
    public class GameSceneController : MonoBehaviour
    {
        [SerializeField] private GameCore _gameCore;
        [SerializeField] private HeroesView _heroesView;

        private void Awake()
        {
            _gameCore.Init();
        }

        private void Start()
        {
            _heroesView.Init();
            _heroesView.gameObject.SetActive(true);
        }

        private void OnApplicationQuit()
        {
            _heroesView.gameObject.SetActive(false);
            _heroesView.Flush();

            _gameCore.Flush();
        }
    }
}