using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueClickManager : MonoBehaviour {

	public void NextPhase()
    {
        if (PlayerPrefs.GetInt("Activity") == 0) FindObjectOfType<FirstActivity>().OnClickInfoPanelButton();
        else if (PlayerPrefs.GetInt("Activity") == 1) FindObjectOfType<SecondActivity>().OnClickInfoPanelButton();
    }
}
