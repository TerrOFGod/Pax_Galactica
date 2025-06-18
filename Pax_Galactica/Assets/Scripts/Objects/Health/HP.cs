using UnityEngine;
using UnityEngine.Events;

public class HP : MonoBehaviour
{
    [SerializeField]
    private int maxCountHP;
    [SerializeField]
    private UnityEvent eventTakeDamage;
    [SerializeField]
    private UnityEvent eventDestroy;
    [SerializeField]
    private Visualizer[] visualizers;

    private int currentCountHP;

    private void Awake()
    {
        currentCountHP = maxCountHP;
        UpdateVisualizers();
    }

    public void TakeDamage(int count)
    {
        var nextHPCount = Mathf.Max(0, currentCountHP - count);

        if (nextHPCount != 0)
        {
            eventTakeDamage.Invoke();
            currentCountHP = nextHPCount;
        }
        else
        {
            Destroy();
        }

        UpdateVisualizers();
    }

    public void UpdateVisualizers()
    {
        for (int i = 0; i < visualizers.Length; i++)
        {
            visualizers[i].Set(currentCountHP, maxCountHP);
        }
    }

    private void Destroy()
    {
        eventDestroy.Invoke();
        Destroy(gameObject);
    }
}