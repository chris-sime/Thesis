using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivityManager : MonoBehaviour {


    [SerializeField]
    private GameObject[] Activites;

    [SerializeField]
    private GameObject[] ActivityEnablers;

	void Start () {
        foreach (var activity in Activites)
        {
            activity.SetActive(false);
        }
    }

    public void NextActivity()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(1);
    }

    public void SetActivityCompleted(int activityCompleted)
    {
        if (activityCompleted > PlayerPrefs.GetInt("Activity")) PlayerPrefs.SetInt("Activity", activityCompleted);
    }
    
    public void DisableActivityEnablers()
    {
        foreach (var activityEnabler in ActivityEnablers)
        {
            activityEnabler.SetActive(false);
        }
    }
}
