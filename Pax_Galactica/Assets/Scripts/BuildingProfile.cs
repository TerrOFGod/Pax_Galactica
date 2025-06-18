using UnityEngine;

[CreateAssetMenu(menuName = "Buildings/Profile")]
public class BuildingProfile : ScriptableObject //для создания листа зданий
{
    public BuildingView BuildingView;
    public string Name;
    public Sprite Icon;
    public float Price;
    public GameObject Building;
}
