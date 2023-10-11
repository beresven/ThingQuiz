using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualChoice : MonoBehaviour
{
    public GameObject ChoisenThingObj;

    public delegate void ChoisenThing(GameObject go);
    public event ChoisenThing ButtonIsTaken;

    public void OnClick()
    {
        Debug.Log(ChoisenThingObj.name);
        ButtonIsTaken?.Invoke(ChoisenThingObj != null ? ChoisenThingObj : null);
    }
}
