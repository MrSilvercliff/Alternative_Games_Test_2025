using _Project.Scripts.Project.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Project.Singleton
{
    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour, IInitializable, IFlushable where T : MonoBehaviourSingleton<T>
    {
        public static T Instance => _instance;

        private static T _instance;

        protected virtual void Awake()
        {
            _instance = (T)this;
        }

        public abstract bool Init();

        public abstract bool Flush();
    }
}
