using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
    [SerializeField]
    private string pathProfiles = "Buildings/";
    public GameObject BuildingButtonTemplate;
    [SerializeField]
    private Transform _buttonParent;
    private List<BuildingProfile> _buildings;

    private List<BuildingPresentOnButton> buildingButtons = new List<BuildingPresentOnButton>();

    void Start()
    {
        _buildings = Resources.LoadAll<BuildingProfile>(pathProfiles).ToList();// получение листа зданий и создание кнопок

        foreach (var building in _buildings)
        {
            var buttonGo = Instantiate(BuildingButtonTemplate, _buttonParent);
            var buildingButton = buttonGo.GetComponent<BuildingPresentOnButton>();
            buildingButtons.Add(buildingButton);
            buildingButton.Present(building);
            //buildingButton.gameObject.SetActive(false);
        }
    }
}
