using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
    public GameObject BuildingButtonTemplate;
    [SerializeField]
    private Transform _buttonParent;
    private List<BuildingProfile> _buildings;
    void Start()
    {
        _buildings = Resources.LoadAll<BuildingProfile>("Buildings/").ToList();// получение листа зданий и создание кнопок

        foreach (var building in _buildings)
        {
            var buttonGo = Instantiate(BuildingButtonTemplate, _buttonParent);
            buttonGo.GetComponent<BuildingPresentOnButton>().Present(building);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
