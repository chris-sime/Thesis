using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondActivity : Activities {

    bool MacedonianTulumusCompleted = false;
    bool PhiliposIsDropedInTulumusCompleted = false;
    bool FollowPathToMiezaCompleted = false;


    public void SetMacedonianTulumusCompleted() { MacedonianTulumusCompleted = true; }
    public void SetPhiliposIsDropedInTulumusCompleted() { PhiliposIsDropedInTulumusCompleted = true; }
    public void SetFollowPathToMiezaCompleted() { FollowPathToMiezaCompleted = true; }

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Activity") != 1) enabled = false;
    }

    void Start()
    {
        ShowPrompts();
    }

    public void OnClickInfoPanelButton()
    {
        UIManager.instance.HideInfoPanel();

        if (!MacedonianTulumusCompleted)
        {
            SetMacedonianTulumusCompleted();
        }
        else if (!PhiliposIsDropedInTulumusCompleted)
        {
            SetPhiliposIsDropedInTulumusCompleted();
        }
        else if (!FollowPathToMiezaCompleted)
        {
            SetFollowPathToMiezaCompleted();
        }
        ShowPrompts();
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

    public void OnClickPromptPanelButton()
    {
        promptPanelEnabler.Disable();
        okButtonEnabler.Disable();
    }

    private void Update()
    {
        ProgressActivity();
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
            //TODO: Set Aristotelis position at Mieza
        }
        if (FollowPathToMiezaCompleted)
        {
            //TODO: develop 3rd phase
            activityManager.NextActivity();
        }
    }
    IEnumerator ShowPromptAfterSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        UIManager.instance.ShowPromptPanel("Δραστηριότητα 2η:", promptInfo);
    }
}
