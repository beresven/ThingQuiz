using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject ManualChoice;
    [SerializeField] public GameObject RandomChoice;

    [SerializeField] public GameObject ThingPlace;
    
    [SerializeField] public GameObject RestartButton;
    [SerializeField] public GameObject BackButton;

    [SerializeField] private float speed;

    private GameObject ChoisenThingObj;


    private void Start()
    {
        RandomChoice randomChoice = RandomChoice.GetComponent<RandomChoice>();
        ManualChoice manualChoice = ManualChoice.GetComponent<ManualChoice>();

        RestartButton.GetComponent<Button>().onClick.AddListener(DoRestart);
        BackButton.GetComponent<Button>().onClick.AddListener(DoBack);

        randomChoice.ButtonIsTaken += DoStart;
        manualChoice.ButtonIsTaken += DoStart;
    }

    private void DoBack()
    {
        throw new NotImplementedException();
    }
    private void DoRestart()
    {
        RandomChoice.SetActive(true);
        ManualChoice.SetActive(true);
        Destroy(ChoisenThingObj);
    }
    private void DoStart(GameObject go)
    {
        if (go != null)
        {
            Destroy(ChoisenThingObj);
            ChoisenThingObj = Instantiate(go, ThingPlace.transform.parent,true);
            RandomChoice.SetActive(false);
            ManualChoice.SetActive(false);
        }
    }
    private void Update()
    {
        if (ChoisenThingObj != null)
            ChoisenThingObj.transform.position = Vector3.Lerp(ChoisenThingObj.transform.position, ThingPlace.transform.position, speed * Time.deltaTime);
    }
}
