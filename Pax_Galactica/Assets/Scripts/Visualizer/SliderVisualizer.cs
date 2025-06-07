using UnityEngine;
using UnityEngine.UI;

public class SliderVisualizer : Visualizer
{
    [SerializeField]
    private Image slider;

    public override void Set(float currentValue, float maxValue)
    {
        slider.fillAmount = currentValue / maxValue;
    }
}