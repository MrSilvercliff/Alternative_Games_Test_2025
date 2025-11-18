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

        /// <summary>
        /// EDITOR ONLY!
        /// </summary>
        /// <param name="heroesData"></param>
        public void SetHeroesData(List<HeroData> heroesData)
        { 
            _heroDataList = heroesData;
        }
    }

    [Serializable]
    public class HeroData
    {
        public Sprite Portrait => _portrait;
        public string Name => _name;
        public string Description => _description;

        [SerializeField] private Sprite _portrait;
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        public HeroData(string name, string description, Sprite portrait)
        {
            _name = name;
            _description = description;
            _portrait = portrait;
        }
    }
}