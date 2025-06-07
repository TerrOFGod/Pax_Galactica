using TMPro;
using UnityEngine;

public class TextVisualizer : Visualizer
{
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private bool toFloor;

    public override void Set(float currentValue, float maxValue)
    {
        text.text = (toFloor ? Mathf.FloorToInt(currentValue) : currentValue).ToString();
    }
}