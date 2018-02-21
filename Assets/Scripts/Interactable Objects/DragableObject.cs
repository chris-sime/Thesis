﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : Interactable {

    Vector3 startingPosition;
    public GameObject planeDragHelper;
    Transform objectHit;
    RaycastHit hit;

    //[SerializeField]
    //private GameObject dropArea;

    bool isDraging = false;
    bool isDroppedinCorrectArea = false;
    bool hasStartedDraging = false;

    LayerMask layerMask = 1 << 8;
    
    
    void Start () {
        startingPosition = transform.position;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.name == "Start")
        {
            hasStartedDraging = true;
        }
        if (coll.transform.tag == "Trail" && hasStartedDraging)
        {
            isDraging = true;
            if (coll.transform.name == "End")
            {
                isDroppedinCorrectArea = true;
            }
        }       
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.transform.tag == "Trail")
        {
            transform.position = startingPosition;
            isDraging = false;
        }
            
    }

    // Update is called once per frame
    void Update () {
        DragObject();
    }


    private void DragObject()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    objectHit = hit.transform;
                    if (objectHit == this.transform)
                    { 
                        transform.position = new Vector3(transform.position.x, transform.position.y + 40, transform.position.z);
                    }
                }
            }
            if ((Input.GetTouch(i).phase == TouchPhase.Moved || Input.GetTouch(i).phase == TouchPhase.Stationary))
            {
                // Construct a ray from the current touch coordinates
                // raycast with layermask in order to hit only the helper plane
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                {
                    objectHit = hit.transform;
                    if (objectHit == planeDragHelper.transform)
                    {
                        transform.position = Vector3.Lerp(transform.position, hit.point, Time.deltaTime * 100);
                    }
                }
            }
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                if (isDroppedinCorrectArea)
                {
                    UIManager.instance.ShowInfoPanel(objectName, objectInfo, true);
                }
                else if (hasStartedDraging)
                {
                    hasStartedDraging = false;
                    isDraging = false;
                    transform.position = startingPosition;
                }
            }
        }
    }
}
