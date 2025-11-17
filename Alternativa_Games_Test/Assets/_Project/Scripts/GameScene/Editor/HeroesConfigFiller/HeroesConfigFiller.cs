using _Project.Scripts.GameScene.Configs;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.GameScene.Editor.HeroesConfigFiller
{
    [CreateAssetMenu(fileName = "HeroesConfigFiller", menuName = "_Project/Configs/GameScene/Editor/Heroes Config Filler")]
    public class HeroesConfigFiller : ScriptableObject
    {
        [SerializeField] private HeroesConfig _heroesConfig;
        [SerializeField] private List<Sprite> _heroesPortraits;
        [SerializeField] private TextAsset _heroesNames;
        [SerializeField] private TextAsset _heroesDescriptions;

        public void FillHeroesConfig()
        {
            var heroesData = CreateHeroDataList();
            _heroesConfig.SetHeroesData(heroesData);
            EditorUtility.SetDirty(_heroesConfig);
        }

        private List<HeroData> CreateHeroDataList()
        {
            var names = _heroesNames.text.Split('\n');
            var descriptions = _heroesDescriptions.text.Split('\n');

            var result = new List<HeroData>();

            for (int i = 0; i < names.Length; i++)
            { 
                var name = names[i];
                var description = descriptions[i];
                var portrait = _heroesPortraits[i];
                var heroData = new HeroData(name, description, portrait);
                result.Add(heroData);
            }

            return result;
        }
    }

    [UnityEditor.CustomEditor(typeof(HeroesConfigFiller))]
    public class HeroesConfigFillerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("FILL HEROES CONFIG"))
                OnFillHeroesConfigButtonClick();
        }

        private void OnFillHeroesConfigButtonClick()
        {
            var config = (HeroesConfigFiller)target;
            config.FillHeroesConfig();
        }
    }
}