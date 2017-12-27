using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstActivity : MonoBehaviour {

    bool PhiliposCompleted = false;
    bool FalagaCompleted = false;
    bool ChearoneaCompleted = false;

    public void SetPhiliposCompleted() { PhiliposCompleted = true; }
    public void SetFalagaCompleted() { FalagaCompleted = true; }
    public void SetChearoneaCompleted() { ChearoneaCompleted = true; }

    public GameObject InfoPanel;
    public GameObject ContinueButton;
    [Space]
    public GameObject[] GameObjects;


    ToggleEnable infoPanelEnabler;
    ToggleEnable continueButtonEnabler;

    private void Start()
    {
        infoPanelEnabler = InfoPanel.GetComponent<ToggleEnable>();
        continueButtonEnabler = ContinueButton.GetComponent<ToggleEnable>();
    }

    public void OnClickInfoPanelButton()
    {
        infoPanelEnabler.Disable();
        continueButtonEnabler.Disable();

        if (!PhiliposCompleted)
        {
            SetPhiliposCompleted();
        }
        else if (!FalagaCompleted)
        {
            SetFalagaCompleted();
        }
        else if (!ChearoneaCompleted)
        {
            SetChearoneaCompleted();
        }
    }

    private void Update()
    {
        if (PhiliposCompleted)
        {
            //deactivate the objects of the completed phase of the activity
            GameObjects[0].SetActive(false); //Philipos
            //activate the objects required for the next phase of the activity
            GameObjects[1].SetActive(true);  //Peltastis
            GameObjects[2].SetActive(true);  //Falagga
            GameObjects[3].SetActive(true);  //Athanatos
        }
        if (FalagaCompleted)
        {
            //deactivate the objects of the completed phase of the activity
            GameObjects[1].SetActive(false);  //Peltastis
            GameObjects[2].SetActive(false);  //Falagga
            GameObjects[3].SetActive(false);  //Athanatos
            //activate the objects required for the next phase of the activity
            GameObjects[4].SetActive(true);  //Chearonea
            GameObjects[5].SetActive(true);  //Stagira
            GameObjects[6].SetActive(true);  //Florina
        }
    }
}
