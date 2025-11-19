using _Project.Scripts.GameScene.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.GameScene.UI.Widgets.Hero
{
    public class HeroWidgetView : MonoBehaviour
    {
        [Header("SELECTABLE VIEW")]
        [SerializeField] private Color _notSelectedColor;
        [SerializeField] private Color _selectedColor;
        [SerializeField] private Image _backImage;

        [Header("HERO WIDGET VIEW")]
        [SerializeField] private Image _portraitImage;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _descriptionText;

        public void Refresh(HeroData widgetData)
        {
            _portraitImage.sprite = widgetData.Portrait;
            _nameText.text = widgetData.Name;
            _descriptionText.text = widgetData.Description;
        }

        public void SetSelected(bool selected)
        {
            if (selected)
                _backImage.color = _selectedColor;
            else
                _backImage.color = _notSelectedColor;
        }
    }
}