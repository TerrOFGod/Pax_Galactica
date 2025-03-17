using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    [SerializeField]
    private List<Unit> allUnits;

    private List<Unit> selectedUnits = new List<Unit>();

    private static Units instance;
    public static Units Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<Units>();
            }
            return instance;
        }
    }

    public List<Unit> AllUnits => allUnits;
    public List<Unit> SelectedUnits => selectedUnits;

    public void AddUnit(Unit unit)
    {
        allUnits.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        allUnits.Remove(unit);
    }

    public void AddSelectedUnit(Unit unit)
    {
        selectedUnits.Add(unit);
    }

    public void RemoveSelectedUnit(Unit unit)
    {
        selectedUnits.Remove(unit);
    }

    public void Select()
    {
        for (int i = 0; i < selectedUnits.Count; i++)
        {
            selectedUnits[i].Select();
        }
    }

    public void Deselect()
    {
        for (int i = 0; i < selectedUnits.Count; i++)
        {
            selectedUnits[i].Deselect();
        }

        selectedUnits = new List<Unit>();
    }
}