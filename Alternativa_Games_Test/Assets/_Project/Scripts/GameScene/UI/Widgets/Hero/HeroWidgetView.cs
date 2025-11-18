using _Project.Scripts.GameScene.Configs;
using _Project.Scripts.Project.UI.Widgets.ScrollRects.WithSelect;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroWidgetView : SelectableWidgetView<HeroData>
    {
        [Header("HERO WIDGET VIEW")]
        [SerializeField] private Image _portraitImage;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _descriptionText;

        public override void Refresh(HeroData widgetData)
        {
            _portraitImage.sprite = widgetData.Portrait;
            _nameText.text = widgetData.Name;
            _descriptionText.text = widgetData.Description;
        }
    }
}