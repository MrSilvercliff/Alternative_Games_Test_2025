using UnityEngine;

namespace _Project.Scripts.Project.ObjectPools
{
    public interface IPoolable
    {
        void OnCreate();
        void OnSpawn();
        void OnDespawn();
    }
}
