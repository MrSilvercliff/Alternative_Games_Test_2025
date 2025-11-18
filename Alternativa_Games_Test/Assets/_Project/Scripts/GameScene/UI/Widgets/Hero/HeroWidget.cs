using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.Project.ObjectPools;
using _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect;
using _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelectAndInteract;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroWidget : SelectableInteractableWidget<HeroWidget, HeroData, HeroWidgetView>, IPoolable
    {
        [SerializeField] private Button _buttonExpand;
        [SerializeField] private GameObject _description;

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
            _data = null;
        }

        private void OnButtonExpandClick()
        {
            ToggleDescription();
            InvokeSelectEvent(this);
        }

        public override void Interact()
        {
            ToggleDescription();
        }

        private void ToggleDescription()
        {
            var descriptionIsActive = _description.activeInHierarchy;
            var newActive = !descriptionIsActive;
            _description.SetActive(newActive);
        }
    }
}