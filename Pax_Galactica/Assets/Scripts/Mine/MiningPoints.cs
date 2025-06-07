using System;
using UnityEngine;

public class MiningPoints : MonoBehaviour
{
    [SerializeField]
    private Vector3[] points;
    [Header("Gizmos")]
    [SerializeField]
    private Color colorGizmos = Color.magenta;
    [SerializeField]
    private float sphereSize = 0.2f;

    public Vector3[] Points => points;

    public Vector3 GetNearestPoint(Vector3 position)
    {
        if (points == null || points.Length == 0)
        {
            throw new Exception("Нет точек для добычи ресурсов!");
        }

        var nearestPointIndex = 0;

        for (int i = 0; i < points.Length; i++)
        {
            if (Vector3.Distance(points[i], position) > Vector3.Distance(points[nearestPointIndex], position))
            {
                nearestPointIndex = i;
            }
        }

        return points[nearestPointIndex];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = colorGizmos;

        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawSphere(points[i], sphereSize);
        }
    }

    private static MiningPoints instance;
    public static MiningPoints Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<MiningPoints>();
            }

            return instance;
        }
    }
}