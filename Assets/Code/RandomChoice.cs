using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomChoice : MonoBehaviour
{
    public GameObject Content;

    public delegate void ChoisenThing(GameObject go);
    public event ChoisenThing ButtonIsTaken;

    public void OnClick()
    {
        var Buttons = Content.GetComponentsInChildren<Button>();
        ButtonIsTaken(Buttons[Random.Range(0, 27)].gameObject);
        //TODO: back 0..27
    }
}
