using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityEnabler : MonoBehaviour {

    [SerializeField] GameObject activityToEnable;
    [SerializeField] int activityIdToEnable;
    [Space]
    [SerializeField] GameObject enabledFlag;
    [SerializeField] GameObject disabledFlag;
    

    Transform objectHit;
    RaycastHit hit;

    void Start()
    {
        if(activityIdToEnable <= PlayerPrefs.GetInt("Activity"))
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
                            enabledFlag.SetActive(false);
                            disabledFlag.SetActive(false);
                            activityToEnable.SetActive(true);
                            gameObject.SetActive(false);
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
