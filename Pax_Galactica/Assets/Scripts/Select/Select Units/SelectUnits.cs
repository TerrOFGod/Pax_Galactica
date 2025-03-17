using UnityEngine;

[RequireComponent(typeof(Units))]
public class SelectUnits : MonoBehaviour
{
    [SerializeField]
    private DrawSelectUnits draw;

    private void OnGUI()
    {
        draw.OnGUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartSelect();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            EndSelect();
        }
    }

    private void StartSelect()
    {
        Units.Instance.Deselect();
    }

    private void EndSelect()
    {
        var rect = draw.GetRect();
        var units = Units.Instance.AllUnits;

        for (int i = 0; i < units.Count; i++)
        {
            Vector2 unitPosition = Camera.main.WorldToScreenPoint(units[i].transform.position);

            if (CheckUnitInRect(unitPosition, rect))
            {
                Units.Instance.AddSelectedUnit(units[i]);
            }
        }

        Units.Instance.Select();
    }

    private bool CheckUnitInRect(Vector2 positionUnit, Rect rect)
    {
        return rect.position.x - (rect.width / 2) <= positionUnit.x &&
            rect.position.x + (rect.width / 2) >= positionUnit.x &&
            rect.position.y - (rect.width / 2) <= positionUnit.y &&
            rect.position.y + (rect.width / 2) >= positionUnit.y;
    }
}