using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Abstractions;
using UniRx;
using Zenject;

public class BottomLeftUI : MonoBehaviour
{
    [SerializeField] private Image _selectedImage;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _sliderBackground;
    [SerializeField] private Image _sliderFillImage;
   // [Inject] private IObservable<ISelectable> _selectedValue;
    private void Start()
    {
        //_selectedValue.Subscribe(OnSelected);
    }
    private void OnSelected(ISelectable selected)
    {
        _selectedImage.enabled = selected != null;
        _healthSlider.gameObject.SetActive(selected != null);
        _text.enabled = selected != null;
        if (selected != null)
        {
            _selectedImage.sprite = selected.Icon;
            _text.text = $"{selected.Health}/{selected.MaxHealth}";
            _healthSlider.minValue = 0;
            _healthSlider.maxValue = selected.MaxHealth;
            _healthSlider.value = selected.Health;
            var color = Color.Lerp(Color.red, Color.green, selected.Health / (float)selected.MaxHealth);
            _sliderBackground.color = color * 0.5f;
            _sliderFillImage.color = color;
        }
    }
}