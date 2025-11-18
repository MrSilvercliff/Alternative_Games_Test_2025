using System;
using UnityEngine;

namespace _Project.Scripts.Project.ObjectPools
{
    [Serializable]
    public class ObjectPoolInitData
    {
        public GameObject Prefab => _prefab;
        public Transform Container => _container;
        public int InitCount => _initCount;

        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _container;
        [SerializeField] private int _initCount;
    }
}
