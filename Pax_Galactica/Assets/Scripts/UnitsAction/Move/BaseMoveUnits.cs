using UnityEngine;

public class BaseMoveUnits : MonoBehaviour
{
    [SerializeField]
    private float distanceBetweenUnits;

    public virtual void Move(Vector3 point)
    {
        if (Units.Instance.SelectedUnits == null)
        {
            return;
        }

        var count = Units.Instance.SelectedUnits.Count;
        var sqrt = Mathf.CeilToInt(Mathf.Sqrt(count));

        for (int i = 0; i < sqrt; i++)
        {
            for (int j = 0; j < sqrt; j++)
            {
                var nextIndexUnit = i * sqrt + j;
                if (nextIndexUnit >= count)
                {
                    return;
                }

                Units.Instance.SelectedUnits[nextIndexUnit].Move(GetPosition(point, i, j, sqrt, count));
            }
        }

        //for (int i = 0; i < Units.Instance.SelectedUnits.Count; i++)
        //{
        //    int row = i / columns;
        //    int col = i % columns;

        //    Vector3 offset = new Vector3(col * spacing, 0, row * spacing);
        //    Vector3 targetPos = center + offset;

        //    Units.Instance.SelectedUnits[i].Move(GetPosition(point, row, col, sqrt));
        //}
    }

    private Vector3 GetPosition(Vector3 center, int x, int z, int columns, float count)
    {
        var columnsHalf = (columns - 1) / 2.0f;

        var linesHalf = (Mathf.CeilToInt(count / columns) - 1) / 2.0f;

        return new Vector3(center.x + ((-linesHalf + x) * distanceBetweenUnits), center.y, center.z + ((-columnsHalf + z) * distanceBetweenUnits));
    }
}