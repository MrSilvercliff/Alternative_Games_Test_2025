using _Project.Scripts.Project.Log;
using System.Collections.Generic;
using UnityEngine;


namespace _Project.Scripts.Project.ObjectPools
{
    public interface IMonoBehaviourPool<T>
    {
        T Spawn();
        void Despawn(T obj);
    }

    public class MonoBehaviourPool<T> : IMonoBehaviourPool<T> where T : Component, IPoolable
    {
        private T _sourceObject;
        private readonly Stack<T> _stack;
        private readonly Transform _parent;

        public MonoBehaviourPool(GameObject prefab, Transform parent = null, int initCount = 0)
        {
            var tryResult = prefab.TryGetComponent<T>(out _sourceObject);

            if (!tryResult)
            {
                LogUtils.Error(this, $"PREFAB HAS NO COMPONENT [{typeof(T).Name}]! CANT INIT OBJECT POOL!");
                return;
            }

            _stack = new();
            _parent = parent == null ? _sourceObject.transform.parent : parent;

            if (initCount > 0)
                WarmingUp(initCount);
        }

        public T Spawn()
        {
            if (_stack.Count == 0)
                Instantiate();

            T obj = _stack.Pop();
            obj.OnSpawn();
            return obj;
        }

        public void Despawn(T obj)
        {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(_parent);
            obj.OnDespawn();
            _stack.Push(obj);
        }

        private void WarmingUp(int count)
        {
            for (int i = 0; i < count; i++)
                Instantiate();
        }

        private T Instantiate()
        {
            var newObj = Object.Instantiate(_sourceObject, _parent);
            newObj.gameObject.SetActive(false);
            newObj.transform.SetParent(_parent);
            _stack.Push(newObj);
            newObj.OnCreate();
            return newObj;
        }
    }
}

