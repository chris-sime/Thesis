﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondActivity : Activities
{

    bool MacedonianTulumusCompleted = false;
    bool PhiliposIsDropedInTulumusCompleted = false;
    bool FollowPathToMiezaCompleted = false;

    public void SetMacedonianTulumusCompleted() { MacedonianTulumusCompleted = true; }
    public void SetPhiliposIsDropedInTulumusCompleted() { PhiliposIsDropedInTulumusCompleted = true; }
    public void SetFollowPathToMiezaCompleted() { FollowPathToMiezaCompleted = true; }

    private void OnEnable()
    {
        ShowPrompts();
    }

    public void OnClickInfoPanelButton()
    {
        UIManager.instance.HideInfoPanel();

        if (!MacedonianTulumusCompleted)
        {
            SetMacedonianTulumusCompleted();
            ShowPrompts();
        }
        else if (!PhiliposIsDropedInTulumusCompleted)
        {
            SetPhiliposIsDropedInTulumusCompleted();
            ShowPrompts();
        }
        else if (!FollowPathToMiezaCompleted)
        {
            SetFollowPathToMiezaCompleted();
            ShowPrompts();
        }

    }

    ////Probably remove later
    //public void OnClickPromptPanelButton()
    //{
    //    promptPanelEnabler.Disable();
    //    okButtonEnabler.Disable();
    //}

    private void Update()
    {
        ProgressActivity();
    }

    private void ShowPrompts()
    {
        if (!MacedonianTulumusCompleted)
        {
            promptInfo = Prompts[0];
            StartCoroutine(ShowPromptAfterSeconds(0.1f));
        }
        else if (!PhiliposIsDropedInTulumusCompleted)
        {
            promptInfo = Prompts[1];
            StartCoroutine(ShowPromptAfterSeconds(0.1f));
        }
        else if (!FollowPathToMiezaCompleted)
        {
            promptInfo = Prompts[2];
            StartCoroutine(ShowPromptAfterSeconds(0.1f));
        }
    }


    private void ProgressActivity()
    {
        if (MacedonianTulumusCompleted)
        {
            //activate the objects required for the next phase of the activity
            GameObjects[1].SetActive(true);  //Philipos
            GameObjects[2].SetActive(true);  //Darios
            GameObjects[3].SetActive(true);  //Aristotelis
            GameObjects[0].GetComponent<PopUpObjectInfo>().enabled = false;

        }
        if (PhiliposIsDropedInTulumusCompleted)
        {
            //deactivate the objects of the completed phase of the activity
            GameObjects[0].SetActive(false);  //Makedonikos tafos
            GameObjects[1].SetActive(false);  //Philipos
            GameObjects[2].SetActive(false);  //Darios

            GameObjects[3].transform.position = GameObjects[4].transform.position; //Set Aristotelis position at Mieza
            GameObjects[5].SetActive(true); //Trail to Mieza
            GameObjects[6].SetActive(true); //Alexander

        }
        if (FollowPathToMiezaCompleted)
        {
            GameObjects[6].transform.position = GameObjects[7].transform.position;
            activityManager.SetActivityCompleted(2);
            UIManager.instance.ShowVictoryScreen();

        }

    }

    IEnumerator ShowPromptAfterSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        UIManager.instance.ShowPromptPanel("Δραστηριότητα 2η:", promptInfo);
    }
}
