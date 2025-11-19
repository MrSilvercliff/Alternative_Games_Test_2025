using _Project.Scripts.Project.Core;
using _Project.Scripts.Project.Interfaces;
using System;
using UnityEngine;
using UnityEngine.UI;
using ZerglingUnityPlugins.Tools.Scripts.Mono;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroSmoothExpandWidget : MonoBehaviour, IInitializable, IFlushable, IMonoUpdatable
    {
        public event Action ExpandStartEvent;
        public event Action ExpandEndEvent;

        [SerializeField] private LayoutElement _layoutElement;
        [SerializeField] private GameObject _descriptionText;
        [SerializeField] private float _expandedHeight;
        [SerializeField] private float _lerpTMultiplier;

        private const int EXPAND_DIRETION_SHOW_DESCRIPTION = 1;
        private const int EXPAND_DIRETION_HIDE_DESCRIPTION = -1;

        private float _startHeight;
        private float _endHeight;
        private float _lerpT;

        private bool _expandInProgress;
        private int _expandDirection;

        public bool Init()
        {
            _expandInProgress = false;
            _expandDirection = 0;
            return true;
        }

        public bool Flush()
        {
            if (!_expandInProgress)
                return true;

            ProjectCore.Instance.MonoUpdater.UnSubscribe(this);
            _expandInProgress = false;
            _expandDirection = 0;
            return true;
        }

        public void ToggleExpand()
        {
            if (_expandInProgress)
                return;

            _expandInProgress = true;
            _lerpT = 0.0f;

            if (_expandDirection == 0 || _expandDirection == EXPAND_DIRETION_HIDE_DESCRIPTION)
            {
                _startHeight = _layoutElement.minHeight;
                _endHeight = _expandedHeight;
                _expandDirection = EXPAND_DIRETION_SHOW_DESCRIPTION;
            }
            else
            {
                _descriptionText.SetActive(false);
                _startHeight = _expandedHeight;
                _endHeight = _layoutElement.minHeight;
                _expandDirection = EXPAND_DIRETION_HIDE_DESCRIPTION;
            }

            ExpandStartEvent?.Invoke();
            ProjectCore.Instance.MonoUpdater.Subscribe(this);
        }

        public void OnUpdate()
        {
            if (_expandDirection == EXPAND_DIRETION_SHOW_DESCRIPTION)
                OnUpdateExpandShow();
            else
                OnUpdateExpandHide();
        }

        private void OnUpdateExpandShow()
        {
            if (_lerpT >= 1.0f)
            {
                _descriptionText.SetActive(true);
                OnExpandEnd();
                return;
            }

            IncreaseLerpT();
            UpdateHeight();
        }

        private void OnUpdateExpandHide()
        {
            if (_lerpT >= 1.0f)
            {
                OnExpandEnd();
                return;
            }

            IncreaseLerpT();
            UpdateHeight();
        }

        private void IncreaseLerpT()
        {
            var deltaTime = Time.deltaTime;
            _lerpT += deltaTime * _lerpTMultiplier;
        }

        private void UpdateHeight()
        {
            var height = Mathf.Lerp(_startHeight, _endHeight, _lerpT);
            _layoutElement.preferredHeight = height;
        }

        private void OnExpandEnd()
        {
            ProjectCore.Instance.MonoUpdater.UnSubscribe(this);
            ExpandEndEvent?.Invoke();
            _expandInProgress = false;
        }
    }
}