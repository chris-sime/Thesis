using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueClickManager : MonoBehaviour
{

    public void NextPhase()
    {
        if (PlayerPrefs.GetInt("CurrentActivity") == 0) {
            Debug.Log("Current Activity: " + PlayerPrefs.GetInt("CurrentActivity") + " CONTINUE BUTTON CLICKED");
            FindObjectOfType<FirstActivity>().OnClickInfoPanelButton();
        }       
        else if (PlayerPrefs.GetInt("CurrentActivity") == 1) FindObjectOfType<SecondActivity>().OnClickInfoPanelButton();
    }
}
