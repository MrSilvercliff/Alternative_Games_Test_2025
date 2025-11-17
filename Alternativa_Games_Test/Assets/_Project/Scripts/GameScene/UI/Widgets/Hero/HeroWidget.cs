using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.Project.ObjectPools;
using UnityEngine;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroWidget : MonoBehaviour, IPoolable
    {
        [SerializeField] private HeroWidgetView _view;

        private HeroData _heroData;

        public void Setup(HeroData heroData)
        { 
            _heroData = heroData;
            _view.Refresh(heroData);
        }

        public void OnCreate()
        {
            gameObject.SetActive(false);
        }

        public void OnSpawn()
        {
        }

        public void OnDespawn()
        {
        }
    }
}