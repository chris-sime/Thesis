using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchOject : Interactable {

    [SerializeField]
    bool isCorrectAnswer;

    Transform objectHit;
    RaycastHit hit;

    private void Start()
    {
        nameUI = InfoPanel.GetComponentsInChildren<Text>()[0];
        infoUI = InfoPanel.GetComponentsInChildren<Text>()[1];

        infoPanelEnabler = InfoPanel.GetComponent<ToggleEnable>();
        continueButtonEnabler = ContinueButton.GetComponent<ToggleEnable>();
    }


    void Update () {
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
                        nameUI.text = objectName;
                        infoUI.text = objectInfo;
                        if (isCorrectAnswer)
                        {
                            infoPanelEnabler.Enable();
                            continueButtonEnabler.Enable();
                        }
                        else { }//add animation for wrong guesses;
                    }
                }
                    
            }
        }
    }
}
