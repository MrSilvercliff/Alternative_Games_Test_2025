using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.Project.ObjectPools;
using _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroWidget : SelectableWidget<HeroWidget, HeroData, HeroWidgetView>, IPoolable
    {
        public event Action ExpandStartEvent;
        public event Action ExpandEndEvent;

        [SerializeField] private Button _buttonExpand;
        [SerializeField] private GameObject _description;
        [SerializeField] private HeroSmoothExpandWidget _expandWidget;

        public void OnCreate()
        {
            gameObject.SetActive(false);
            _buttonExpand.onClick.AddListener(OnButtonExpandClick);
        }

        public void OnSpawn()
        {
            if (_expandWidget != null)
            {
                _expandWidget.ExpandStartEvent += OnExpandStartEvent;
                _expandWidget.ExpandEndEvent += OnExpandEndEvent;
            }
        }

        public void OnDespawn()
        {
            if (_expandWidget != null)
            {
                _expandWidget.ExpandStartEvent -= OnExpandStartEvent;
                _expandWidget.ExpandEndEvent -= OnExpandEndEvent;
            }

            _data = null;
        }

        private void OnButtonExpandClick()
        {
            Interact();
            InvokeSelectEvent(this);
        }

        public void Interact()
        {
            if (_expandWidget == null)
                ToggleDescription();
            else
                _expandWidget.ToggleExpand();
        }

        private void ToggleDescription()
        {
            var descriptionIsActive = _description.activeInHierarchy;
            var newActive = !descriptionIsActive;
            _description.SetActive(newActive);
        }

        private void OnExpandStartEvent()
        {
            ExpandStartEvent?.Invoke();
        }

        private void OnExpandEndEvent()
        {
            ExpandEndEvent?.Invoke();
        }
    }
}