using UnityEngine;

namespace _Project.Scripts.Project.Singleton
{
    public interface IMonoBehaviourSingleton<T> : ISingleton<T>
    { 
    }

    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour, IMonoBehaviourSingleton<T> where T : MonoBehaviourSingleton<T>
    {
        public static T Instance => _instance;

        private static T _instance;

        protected virtual void Awake()
        {
            _instance = this as T;
        }

        public abstract bool Init();

        public abstract bool Flush();
    }
}
