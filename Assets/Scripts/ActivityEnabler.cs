using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityEnabler : MonoBehaviour
{

    [SerializeField] GameObject activityToEnable;
    [SerializeField] int activityIdToEnable;
    [Space]
    [SerializeField]
    GameObject enabledFlag;
    [SerializeField] GameObject disabledFlag;


    Transform objectHit;
    RaycastHit hit;

    ActivityManager activityManager;
    void Start()
    {
        activityManager = FindObjectOfType<ActivityManager>();
        if (activityIdToEnable <= PlayerPrefs.GetInt("ActivitiesCompleted"))
        {
            enabledFlag.SetActive(true);
            disabledFlag.SetActive(false);
        }
        else
        {
            enabledFlag.SetActive(false);
            disabledFlag.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //You can start the activity
                if (enabledFlag.activeSelf)
                {
                    PlayerPrefs.SetInt("CurrentActivity", activityIdToEnable);
                    activityToEnable.SetActive(true);
                    activityManager.DisableActivityEnablers();
                }
                //You are unable to start the activity
                else
                {
                    Debug.Log("you are unable to start this activity");
                    //Throw visual feedback msgs "you are unable to start this activity"
                }
            }
        }

        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                // do stuff if hit
                if (Physics.Raycast(ray, out hit))
                {
                    objectHit = hit.transform;
                    if (objectHit == this.transform)
                    {
                        //You can start the activity
                        if (enabledFlag.activeSelf)
                        {
                            PlayerPrefs.SetInt("CurrentActivity", activityIdToEnable);
                            activityToEnable.SetActive(true);
                            activityManager.DisableActivityEnablers();
                        }
                        //You are unable to start the activity
                        else
                        {
                            Debug.Log("you are unable to start this activity");
                            //Throw visual feedback msgs "you are unable to start this activity"
                        }
                    }
                }
            }
        }
    }


}
