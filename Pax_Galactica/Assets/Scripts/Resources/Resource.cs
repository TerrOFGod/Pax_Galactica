using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]
    private float currentCount;
    [SerializeField]
    private float maxCount;
    [SerializeField]
    private Visualizer[] visualizers;

    public void Add(float count)
    {
        currentCount = Mathf.Min(maxCount, currentCount + count);
        UpdateVisualizers();
    }

    public bool CanRemove(float count) => currentCount >= count;

    public void Remove(float count)
    {
        currentCount = Mathf.Max(0f, currentCount - count);
        UpdateVisualizers();
    }

    public void UpdateVisualizers()
    {
        for (int i = 0; i < visualizers.Length; i++)
        {
            visualizers[i].Set(currentCount, maxCount);
        }
    }
}