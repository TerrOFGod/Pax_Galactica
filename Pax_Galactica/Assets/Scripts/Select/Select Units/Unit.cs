using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private UnityEvent selectEvent;
    [SerializeField]
    private UnityEvent deselectEvent;

    public void Select()
    {
        selectEvent.Invoke();
    }

    public void Deselect()
    {
        deselectEvent.Invoke();
    }
}