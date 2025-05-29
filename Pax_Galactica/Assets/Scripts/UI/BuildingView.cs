using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BuildingView: MonoBehaviour
{
    public Transform CurrentTransform;


    public void Awake()
    {
        CurrentTransform = GetComponent<Transform>();
    }

   public enum State
    {
        Idle,
        Inplacing
    }
}
