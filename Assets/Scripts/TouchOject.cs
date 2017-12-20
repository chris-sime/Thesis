using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOject : Interactable {

    [SerializeField]
    bool CorrectAnswer;

    Transform objectHit;
    RaycastHit hit;

    // Update is called once per frame
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
                        Debug.Log(objectHit.name);
                        Destroy(gameObject);
                    }
                }
                    
            }
        }
    }
}
