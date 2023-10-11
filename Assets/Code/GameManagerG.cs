using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerG : MonoBehaviour
{
    public GameObject SugTrue;
    public GameObject SugFalse;

    public GameObject ManualChoice;
    public GameObject RandomChoice;

    public GameObject Content;
    public GameObject ThingPlace;
    public GameObject RestartButton;
    public GameObject BackButton;

    [SerializeField] private float speed;

    private GameObject ChoisenThingObj;


    private void Start()
    {
        SugFalse sugFalse = SugFalse.GetComponent<SugFalse>();
        SugTrue sugTrue = SugTrue.GetComponent<SugTrue>();

        ManualChoice manualChoice = ManualChoice.GetComponent<ManualChoice>();
        RandomChoice randomChoice = RandomChoice.GetComponent<RandomChoice>();

        randomChoice.ButtonIsTaken += DoStart;
        manualChoice.ButtonIsTaken += DoStart;

        RestartButton.GetComponent<Button>().onClick.AddListener(DoRestart);
        BackButton.GetComponent<Button>().onClick.AddListener(DoBack);

        sugTrue.ButtonIsTaken += Win;
        sugFalse.ButtonIsTaken += Lose;
    }

    private void DoStart(GameObject go)
    {
        if (go != null)
        {
            Destroy(ChoisenThingObj);
            ChoisenThingObj = Instantiate(go, ThingPlace.transform.parent, true);
            go.SetActive(false);
            RandomChoice.SetActive(false);
            ManualChoice.SetActive(false);
        }
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
    private void Win(GameObject go)
    {
        if (go != null)
        {
            //Button[] Buttons = Content.GetComponentsInChildren<Button>();

            StartCoroutine(Win(Content.GetComponentsInChildren<Button>()));

            ChoisenThingObj = Instantiate(go, ThingPlace.transform.parent,true);
            go.GetComponent<Image>().enabled = false;
        }
    }

    private void Lose(GameObject go)
    {
        if (go != null)
        {
            go.GetComponent<Button>().interactable = false;
        }
    }
    private void Update()
    {
        if (ChoisenThingObj != null)
            ChoisenThingObj.transform.position = Vector3.Lerp(ChoisenThingObj.transform.position, ThingPlace.transform.position, speed * Time.deltaTime);
    }

    IEnumerator Win(Button[] Buttons)
    {
        foreach (Button btn in Buttons.Reverse())
        {
            btn.gameObject.SetActive(false);
            yield return new WaitForSeconds(.1f);
        }
    }
}
