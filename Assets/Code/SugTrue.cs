using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugTrue : MonoBehaviour
{
    public GameObject ChoisenThingObj;

    public delegate void ChoisenThing(GameObject go);
    public event ChoisenThing ButtonIsTaken;

    public void OnClick()
    {
        ButtonIsTaken(ChoisenThingObj != null ? ChoisenThingObj : null);
    }
}
