using _Project.Scripts.Project.Log;
using UnityEngine;

namespace _Project.Scripts.Project.Singleton
{
    public abstract class DontDestroyMonoBehaviourSingleton<T> : MonoBehaviourSingleton<T>
        where T : DontDestroyMonoBehaviourSingleton<T>
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
