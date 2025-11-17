using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.GameScene.Configs
{
    public interface IHeroesConfig
    {
        IReadOnlyList<HeroData> HeroDataList { get; }
    }

    [CreateAssetMenu(fileName = "ScrollItemsConfig", menuName = "_Project/Configs/GameScene/Scroll Items Config")]
    public class HeroesConfig : ScriptableObject, IHeroesConfig
    {
        public IReadOnlyList<HeroData> HeroDataList => _heroDataList;

        [SerializeField] private List<HeroData> _heroDataList;
    }

    [Serializable]
    public class HeroData
    {
        public Sprite Icon => _icon;
        public string TitleText => _titleText;
        public string DescriptionText => _descriptionText;

        [SerializeField] private Sprite _icon;
        [SerializeField] private string _titleText;
        [SerializeField] private string _descriptionText;
    }
}