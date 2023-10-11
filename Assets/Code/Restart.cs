using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject GameManager;
    public GameObject ChoisenThingObj;

    public delegate void ChoisenThing(GameObject go);
    public event ChoisenThing ButtonIsTaken;
    public void OnClick()
    {
        ButtonIsTaken(ChoisenThingObj != null ? ChoisenThingObj : null);
    }
}
