using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstActivity : MonoBehaviour {

    bool PhiliposCompleted = false;
    bool FalagaCompleted = false;
    bool HeroniaCompleted = false;

    public void SetPhiliposCompleted() { PhiliposCompleted = true; }
    public void SetFalagaCompleted() { FalagaCompleted = true; }
    public void SetHeroniaCompleted() { HeroniaCompleted = true; }

    public GameObject InfoPanel;
    public GameObject ContinueButton;
    [Space]
    public GameObject[] GameObjects;

    public void OnClickInfoPanelButton()
    {
        InfoPanel.SetActive(false);
        ContinueButton.SetActive(false);
        if (!PhiliposCompleted)
        {
            SetPhiliposCompleted();
        }
        else if (!FalagaCompleted)
        {
            SetFalagaCompleted();
        }
        else if (!HeroniaCompleted)
        {
            SetHeroniaCompleted();
        }
    }

    private void Update()
    {
        if (PhiliposCompleted)
        {
            GameObjects[0].SetActive(false); //Philipos
            GameObjects[1].SetActive(true);  //Peltastis
            GameObjects[2].SetActive(true);  //Falagga
            GameObjects[3].SetActive(true);  //Athanatos

            //GameObject.Find("").SetActive(true);
            //GameObject.Find("").SetActive(true);
            //GameObject.Find("").SetActive(true);
            //GameObject.Find("").SetActive(true);
        }
    }
}
