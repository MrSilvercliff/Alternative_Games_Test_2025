using UnityEngine;

namespace _Project.Scripts.Project.Singleton
{
    public interface IMonoBehaviourSingleton<T> : ISingleton<T>
    { 
    }

    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour, IMonoBehaviourSingleton<T> where T : MonoBehaviour
    {
        public static T Instance => _instance;

        protected static T _instance;

        private void Awake()
        {
            _instance = this as T;
        }

        public abstract bool Init();

        public abstract bool Flush();
    }
}
