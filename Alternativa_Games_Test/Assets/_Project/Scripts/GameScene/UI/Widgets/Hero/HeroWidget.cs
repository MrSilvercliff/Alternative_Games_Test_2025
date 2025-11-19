using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.Project.ObjectPools;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroWidget : MonoBehaviour, IPoolable
    {
        public event Action<HeroWidget> WidgetSelectEvent;
        public event Action ExpandStartEvent;
        public event Action ExpandEndEvent;

        public RectTransform RectTransform => _rectTransform;
        public RectTransform AnchorTop => _anchorTop;
        public RectTransform AnchorBottom => _anchorBottom;

        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private RectTransform _anchorTop;
        [SerializeField] private RectTransform _anchorBottom;
        [SerializeField] private HeroWidgetView _view;
        [SerializeField] private Button _buttonExpand;
        [SerializeField] private GameObject _description;
        [SerializeField] private HeroSmoothExpandWidget _expandWidget;

        private HeroData _data;

        public void OnCreate()
        {
            gameObject.SetActive(false);
            _expandWidget?.Init();
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
                _expandWidget.Flush();
            }

            _data = null;
        }

        public void SetSelected(bool selected)
        {
            _view.SetSelected(selected);
        }

        public void Setup(HeroData data)
        {
            _data = data;
            _view.Refresh(data);
        }

        private void OnButtonExpandClick()
        {
            WidgetSelectEvent?.Invoke(this);
            Interact();
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