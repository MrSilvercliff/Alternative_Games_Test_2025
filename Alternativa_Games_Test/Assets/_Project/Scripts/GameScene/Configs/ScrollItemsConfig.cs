using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.GameScene.Configs
{
    public interface IScrollItemsConfig
    {
        IReadOnlyList<ScrollItemData> ScrollItems { get; }
    }

    [CreateAssetMenu(fileName = "ScrollItemsConfig", menuName = "_Project/Configs/GameScene/Scroll Items Config")]
    public class ScrollItemsConfig : ScriptableObject, IScrollItemsConfig
    {
        public IReadOnlyList<ScrollItemData> ScrollItems => _scrollItems;

        [SerializeField] private List<ScrollItemData> _scrollItems;
    }

    [Serializable]
    public class ScrollItemData
    {
        public Sprite Icon => _icon;
        public string TitleText => _titleText;
        public string DescriptionText => _descriptionText;

        [SerializeField] private Sprite _icon;
        [SerializeField] private string _titleText;
        [SerializeField] private string _descriptionText;
    }
}