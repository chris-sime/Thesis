using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour {

    public int CurrentActivity { get; set; }

    [SerializeField]
    private GameObject[] Activites;


	void Start () {
        CurrentActivity = 0;
        foreach (var activity in Activites)
        {
            activity.SetActive(false);
        }
        Activites[CurrentActivity].SetActive(true);
    }

    public void NextActivity()
    {
        Activites[CurrentActivity].SetActive(false);
        CurrentActivity++;
        Activites[CurrentActivity].SetActive(true);
    }
}
