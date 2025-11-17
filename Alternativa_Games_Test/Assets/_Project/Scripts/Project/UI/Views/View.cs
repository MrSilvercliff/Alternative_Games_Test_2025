using UnityEngine;

namespace _Project.Scripts.Project.UI.Views
{
    public interface IView
    {
        void Init();
        void Open();
        void Close();
    }

    public abstract class View : MonoBehaviour, IView
    {
        public void Init()
        {
            gameObject.SetActive(false);
            OnInit();
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        protected abstract void OnInit();
    }
}