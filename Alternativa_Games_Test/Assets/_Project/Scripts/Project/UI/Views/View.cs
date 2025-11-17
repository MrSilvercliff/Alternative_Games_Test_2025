using _Project.Scripts.Project.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Project.UI.Views
{
    public interface IView : IInitializable, IFlushable
    {
        void Open();
        void Close();
    }

    public abstract class View : MonoBehaviour, IView
    {
        public bool Init()
        {
            gameObject.SetActive(false);
            var result = OnInit();
            return result;
        }

        public bool Flush()
        {
            var result = OnFlush();
            return result;
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        protected abstract bool OnInit();

        protected abstract bool OnFlush();
    }
}