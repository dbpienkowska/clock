using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Slider;

public class FloatSlider : MonoBehaviour
{
    public float minValue;
    public float maxValue;
    public float startValue;
    public SliderEvent onValueChanged;

    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private Text _minText;
    [SerializeField]
    private Text _maxText;

    private void Awake()
    {
        _slider.minValue = minValue;
        _slider.maxValue = maxValue;
        _slider.onValueChanged = onValueChanged;

        _minText.text = minValue.ToString();
        _maxText.text = maxValue.ToString();

        onValueChanged.Invoke(startValue);
    }
}
