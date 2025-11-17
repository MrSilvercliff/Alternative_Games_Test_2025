using _Project.Scripts.GameScene.UI.Widgets.Hero;
using _Project.Scripts.Project.ObjectPools;
using UnityEngine;

namespace _Project.Scripts.GameScene.ObjectPools
{
    public class HeroWidgetPool : MonoBehaviourPool<HeroWidget>
    {
        public HeroWidgetPool(GameObject prefab, Transform parent = null, int initCount = 0) : base(prefab, parent, initCount)
        {
        }
    }
}