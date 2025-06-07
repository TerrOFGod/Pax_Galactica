using UnityEngine;

public class MiningBuilding : Building
{
    [SerializeField]
    private Transform point;
    [Header("Gizmos")]
    [SerializeField]
    private Color colorGizmos = Color.magenta;
    [SerializeField]
    private float sphereSize = 0.2f;

    public Transform Point => point;

    private void OnDrawGizmos()
    {
        Gizmos.color = colorGizmos;
        Gizmos.DrawSphere(point.position, sphereSize);
    }
}