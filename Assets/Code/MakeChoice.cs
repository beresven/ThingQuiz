using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MakeChoice : MonoBehaviour
{
    public GameObject Chooser;
    private bool _selected = true;


    public void OnClick()
    {
        Chooser.GetComponent<ManualChoice>().ChoisenThingObj = gameObject;

        if (Chooser.GetComponent<ManualChoice>().ChoisenThingObj != null)
        {
            if (_selected)
            {
                GetComponent<Animation>().Play("per1");
            }
            else
            {
                GetComponent<Animation>().Play("per3");
            }
            _selected = !_selected;
        }
    }
}
