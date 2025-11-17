using _Project.Scripts.Project.Interfaces;

namespace _Project.Scripts.Project.Singleton
{
    public abstract class Singleton<T> : IInitializable, IFlushable where T : Singleton<T>, new()
    {
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new T();

                return _instance;
            }
        }

        private static T _instance;

        protected Singleton()
        {
            _instance = (T)this;
        }

        public abstract bool Init();

        public abstract bool Flush();
    }
}
