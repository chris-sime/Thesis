using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour {

    int currentActivity;

    [SerializeField]
    private GameObject[] Activites;


	void Start () {
        currentActivity = PlayerPrefs.GetInt("Activity");
        foreach (var activity in Activites)
        {
            activity.SetActive(false);
        }
        Activites[currentActivity].SetActive(true);
    }

    public void NextActivity()
    {
        Activites[currentActivity].SetActive(false);
        currentActivity++;
        Activites[currentActivity].SetActive(true);
    }
}
