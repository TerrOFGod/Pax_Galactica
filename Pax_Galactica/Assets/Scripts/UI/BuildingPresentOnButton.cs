using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPresentOnButton : MonoBehaviour
{
    public Text BuildingName;
    public Image Icon;
    public Button Button;

    public void Present(BuildingProfile profile) //��������� ������ � ������� ������ ��� �������� ������
    {
        Icon.sprite = profile.Icon;
        BuildingName.text = profile.Name;

        Button.onClick.AddListener(() =>
            {
                PlaceLogick.Instance.Place(profile);
            });
    }
}
