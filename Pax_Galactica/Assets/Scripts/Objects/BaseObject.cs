using UnityEngine;

public class BaseObject : MonoBehaviour
{
    [SerializeField]
    private LayerMask layer;
    [SerializeField]
    private HP health;

    public HP Health => health;
    public LayerMask Layer => layer;
}