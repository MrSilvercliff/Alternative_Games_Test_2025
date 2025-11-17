using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.Project.ObjectPools;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroWidget : MonoBehaviour, IPoolable
    {
        [SerializeField] private HeroWidgetView _view;
        [SerializeField] private Button _buttonExpand;
        [SerializeField] private GameObject _description;

        private HeroData _heroData;

        public void Setup(HeroData heroData)
        { 
            _heroData = heroData;
            _view.Refresh(heroData);
        }

        public void OnCreate()
        {
            gameObject.SetActive(false);
            _buttonExpand.onClick.AddListener(OnButtonExpandClick);
        }

        public void OnSpawn()
        {
        }

        public void OnDespawn()
        {
        }

        private void OnButtonExpandClick()
        {
            var descriptionIsActive = _description.activeInHierarchy;
            var newActive = !descriptionIsActive;
            _description.SetActive(newActive);
        }
    }
}