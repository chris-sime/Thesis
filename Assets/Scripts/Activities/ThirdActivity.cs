using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdActivity : Activities
{

    bool QuizCompleted = false;

    public void SetPhiliposCompleted() { QuizCompleted = true; }

    private void Start()
    {
        ShowPrompts();
    }

    public void OnClickInfoPanelButton()
    {
        UIManager.instance.HideInfoPanel();
        if (!QuizCompleted)
        {
            SetPhiliposCompleted();
            ShowPrompts();
        }
    }

    private void Update()
    {
        ProgressActivity();
    }

    private void ShowPrompts()
    {
        Debug.Log("ShowPrompts");
        if (!QuizCompleted)
        {
            promptInfo = Prompts[0];
            StartCoroutine(ShowPromptAfterSeconds(0.1f));
        }
    }

    private void ProgressActivity()
    {

        /*
         * GameObjects[0] = Alexander
         * GameObjects[1] = AlexandersArmy
         * GameObjects[2] = AlexanderLocation
         * GameObjects[3] = DariusLocation
         * GameObjects[4] = Darius
         * GameObjects[5] = DariusArmy
         * GameObjects[6] = AlexanderArmyGroup
         * GameObjects[7] = DariusArmyGroup
         */

        GameObjects[6].transform.position = Vector3.Lerp(GameObjects[6].transform.position, GameObjects[2].transform.position, Time.deltaTime * 5);
        GameObjects[7].transform.position = Vector3.Lerp(GameObjects[7].transform.position, GameObjects[3].transform.position, Time.deltaTime * 5);
        
        if (QuizCompleted)
        {
            
            activityManager.SetActivityCompleted(1);
            UIManager.instance.ShowVictoryScreen();
        }
    }

    IEnumerator ShowPromptAfterSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);      
        UIManager.instance.ShowPromptPanel("Δραστηριότητα 1η:", promptInfo);
    }

}
