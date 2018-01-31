using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchOject : Interactable {

    [SerializeField]
    bool isCorrectAnswer;

    Transform objectHit;
    RaycastHit hit;


    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
                        if (isCorrectAnswer)
                        {
                            UIManager.instance.ShowInfoPanel(objectName, objectInfo, isCorrectAnswer);
                        }
                        else
                        {
                            animator.SetTrigger("WrongWiggle");
                        }
                    }
                }       
            }
        }
    }
}
