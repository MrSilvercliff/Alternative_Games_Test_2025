using _Project.Scripts.GameScene.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroWidgetView : MonoBehaviour
    {
        [SerializeField] private Image _portraitImage;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _descriptionText;

        public void Refresh(HeroData heroData)
        {
            _portraitImage.sprite = heroData.Portrait;
            _nameText.text = heroData.Name;
            _descriptionText.text = heroData.Description;
        }
    }
}