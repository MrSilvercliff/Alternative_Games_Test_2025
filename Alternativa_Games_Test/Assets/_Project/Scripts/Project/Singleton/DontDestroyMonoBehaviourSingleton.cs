using UnityEngine;

namespace _Project.Scripts.Project.Singleton
{
    public abstract class DontDestroyMonoBehaviourSingleton<T> : MonoBehaviourSingleton<T>
        where T : DontDestroyMonoBehaviourSingleton<T>
    {
        public static new T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject(typeof(T).Name);
                    _instance = go.AddComponent<T>();
                    DontDestroyOnLoad(go);
                }

                return _instance;
            }
        }
    }
}
