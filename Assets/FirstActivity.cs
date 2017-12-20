using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstActivity : MonoBehaviour {

    bool PhiliposCompleted = false;
    bool FalaggaCompleted = false;
    bool HeroniaCompleted = false;

    public void SetPhiliposCompleted() { PhiliposCompleted = true; }
    public void SetFalagaCompleted() { FalaggaCompleted = true; }
    public void SetHeroniaCompleted() { HeroniaCompleted = true; }

    public GameObject InfoPanel;
    public GameObject[] GameObjects;

    public void OnClickInfoPanelButton()
    {
        InfoPanel.SetActive(false);
        if (!PhiliposCompleted)
        {
            SetPhiliposCompleted();
        }
        else if (!FalaggaCompleted)
        {
            SetFalagaCompleted();
        }
        else
        {
            SetHeroniaCompleted();
        }
    }

    private void Update()
    {
        if (PhiliposCompleted)
        {
            GameObjects[0].SetActive(false);
            GameObjects[1].SetActive(true);
            GameObjects[2].SetActive(true);
            GameObjects[3].SetActive(true);
            //GameObject.Find("").SetActive(true);
            //GameObject.Find("").SetActive(true);
            //GameObject.Find("").SetActive(true);
            //GameObject.Find("").SetActive(true);
        }
    }
}
