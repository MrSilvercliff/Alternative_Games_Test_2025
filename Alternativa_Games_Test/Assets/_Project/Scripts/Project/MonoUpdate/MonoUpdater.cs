using _Project.Scripts.Project.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZerglingUnityPlugins.Tools.Scripts.Mono;

namespace _Project.Scripts.Project.MonoUpdate
{
    public interface IMonoUpdater : IInitializable
    {
        void Subscribe(IMonoUpdatable updatable);
        void UnSubscribe(IMonoUpdatable updatable);

        void Subscribe(IMonoFixedUpdatable updatable);
        void UnSubscribe(IMonoFixedUpdatable updatable);

        void Subscribe(IMonoLateUpdatable updatable);
        void UnSubscribe(IMonoLateUpdatable updatable);
    }

    public class MonoUpdater : MonoBehaviour, IMonoUpdater
    {
        private List<IMonoUpdatable> _monoUpdatableObjects;
        private List<IMonoFixedUpdatable> _monoFixedUpdatableObjects;
        private List<IMonoLateUpdatable> _monoLateUpdatableObjects;

        public bool Init()
        {
            _monoUpdatableObjects = new();
            _monoFixedUpdatableObjects = new();
            _monoLateUpdatableObjects = new();
            return true;
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _monoFixedUpdatableObjects.Count; i++)
                _monoFixedUpdatableObjects[i].OnFixedUpdate();
        }

        private void Update()
        {
            for (int i = 0; i < _monoUpdatableObjects.Count; i++)
                _monoUpdatableObjects[i].OnUpdate();
        }

        private void LateUpdate()
        {
            for (int i = 0; i < _monoLateUpdatableObjects.Count; i++)
                _monoLateUpdatableObjects[i].OnLateUpdate();
        }

        public void Subscribe(IMonoUpdatable updatable)
        {
            if (_monoUpdatableObjects.Contains(updatable))
                return;

            _monoUpdatableObjects.Add(updatable);
        }

        public void UnSubscribe(IMonoUpdatable updatable)
        {
            _monoUpdatableObjects.Remove(updatable);
        }


        public void Subscribe(IMonoFixedUpdatable updatable)
        {
            if (_monoFixedUpdatableObjects.Contains(updatable))
                return;

            _monoFixedUpdatableObjects.Add(updatable);
        }

        public void UnSubscribe(IMonoFixedUpdatable updatable)
        {
            _monoFixedUpdatableObjects.Remove(updatable);
        }


        public void Subscribe(IMonoLateUpdatable updatable)
        {
            if (_monoLateUpdatableObjects.Contains(updatable))
                return;

            _monoLateUpdatableObjects.Add(updatable);
        }

        public void UnSubscribe(IMonoLateUpdatable updatable)
        {
            _monoLateUpdatableObjects.Remove(updatable);
        }
    }
}