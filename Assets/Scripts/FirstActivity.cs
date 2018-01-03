using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstActivity : Activities {

    bool PhiliposCompleted = false;
    bool FalagaCompleted = false;
    bool ChearoneaCompleted = false;

   
    public void SetPhiliposCompleted() { PhiliposCompleted = true; }
    public void SetFalagaCompleted() { FalagaCompleted = true; }
    public void SetChearoneaCompleted() { ChearoneaCompleted = true; }

    void Start()
    {
        infoPanelEnabler = InfoPanel.GetComponent<ToggleEnable>();
        continueButtonEnabler = ContinueButton.GetComponent<ToggleEnable>();
        closeButtonEnabler = CloseButton.GetComponent<ToggleEnable>();

        promptPanelEnabler = PromptPanel.GetComponent<ToggleEnable>();
        okButtonEnabler = OkButton.GetComponent<ToggleEnable>();

        ShowPrompts();
    }

    public void OnClickInfoPanelButton()
    {
        infoPanelEnabler.Disable();
        continueButtonEnabler.Disable();
        closeButtonEnabler.Disable();

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

        ShowPrompts();
    }
    
    public void OnClickPromptPanelButton()
    {
        promptPanelEnabler.Disable();
        okButtonEnabler.Disable();
    }

    private void Update()
    { 
        ProgressActivity();
    }

    private void ShowPrompts()
    {
        if (!PhiliposCompleted)
        {
            PromptPanel.GetComponentsInChildren<Text>()[1].text = Promts[0];
            promptPanelEnabler.Enable();
            okButtonEnabler.Enable();
        }
        else if (!FalagaCompleted)
        {
            PromptPanel.GetComponentsInChildren<Text>()[1].text = Promts[1];
            promptPanelEnabler.Enable();
            okButtonEnabler.Enable();
        }
        else if (!ChearoneaCompleted)
        {
            PromptPanel.GetComponentsInChildren<Text>()[1].text = Promts[2];
            promptPanelEnabler.Enable();
            okButtonEnabler.Enable();
        }
    }

    private void ProgressActivity()
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
        if (ChearoneaCompleted)
        {
            GameObjects[4].SetActive(false);  //Chearonea
            GameObjects[5].SetActive(false);  //Stagira
            GameObjects[6].SetActive(false);  //Florina
            activityManager.NextActivity();
        }
    }
}

