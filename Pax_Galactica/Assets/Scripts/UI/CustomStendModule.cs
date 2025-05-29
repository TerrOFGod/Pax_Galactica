using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomStendModule : StandaloneInputModule
{
    public Vector3 GetMousePositionOnGameObject()
    {
        var mainPointerData = GetLastPointerEventData(-1);
        if (mainPointerData == null) return Vector3.zero;
        return mainPointerData.pointerCurrentRaycast.worldPosition;
    }
    public GameObject GetCurrentHoveredGameObject()
    {
        var mainPointerData = GetLastPointerEventData(-1);
        if (mainPointerData == null) return null;
        return mainPointerData.pointerCurrentRaycast.gameObject;
    }
}
