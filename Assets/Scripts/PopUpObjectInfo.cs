﻿using UnityEngine;
using UnityEngine.UI;


public class PopUpObjectInfo : Interactable {

    [SerializeField]
    private bool isCorrectObject = true;

    Camera cam;  
    [SerializeField]
    float hoverTimeUntilPopUp = 1.5f;
    float countdown;

    Transform objectHit;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
        countdown = hoverTimeUntilPopUp;
        cam = FindObjectOfType<Camera>();
    }
	
	// Update is called once per frame
	void Update () {  
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2, 0));
        
        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.transform;
            if(objectHit == this.transform)
            {
                UIManager.instance.Indicator.fillAmount = countdown / hoverTimeUntilPopUp;
                countdown -= Time.deltaTime;
                if(countdown < 0)
                {
                    UIManager.instance.ShowInfoPanel(objectName, objectInfo, isCorrectObject);
                }
            }
        }
        else
        {
            countdown = hoverTimeUntilPopUp;
        }
    }
}
