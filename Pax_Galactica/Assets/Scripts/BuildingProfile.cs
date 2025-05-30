using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buildings/Profile")]
public class BuildingProfile : ScriptableObject //для создания листа зданий
{
    public GameObject BuildingView;
    public string Name;
    public Sprite Icon;
    public float Price;
    public GameObject Building;
}
