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


    private string promptInfo;
    void Start()
    {
        ShowPrompts();
    }

    public void OnClickInfoPanelButton()
    {
        UIManager.instance.HideInfoPanel();

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
    
    //Probably remove later
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
            promptInfo = Prompts[0];
        }
        else if (!FalagaCompleted)
        {
            promptInfo = Prompts[1];
        }
        else if (!ChearoneaCompleted)
        {
            promptInfo = Prompts[2];
        }
        UIManager.instance.ShowPromptPanel("Δραστηριότητα 1η:", promptInfo);
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
            //Move Falagga to Chearonea position
            GameObjects[2].transform.position = GameObjects[4].transform.position;

            activityManager.NextActivity();
        }
    }
}

