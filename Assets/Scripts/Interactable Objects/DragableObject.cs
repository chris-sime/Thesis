using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : Interactable {

    Vector3 startingPosition;
    public GameObject planeDragHelper;
    Transform objectHit;
    RaycastHit hit;

    int trailCountHelper = 0;
    //[SerializeField]
    //private GameObject dropArea;

    bool isDraging = false;
    bool isDroppedinCorrectArea = false;
    bool hasStartedTheTrail = false;

    LayerMask layerMask = 1 << 8;
    
    
    void Start () {
        startingPosition = transform.position;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.name == "Start")
        {
            hasStartedTheTrail = true;
            trailCountHelper++;
        }
        if (coll.transform.tag == "Trail")
        {
            if (!hasStartedTheTrail) transform.position = startingPosition;
            else trailCountHelper++;
        }
        if (coll.transform.name == "End")
        {
            if (!hasStartedTheTrail) transform.position = startingPosition;
            else isDroppedinCorrectArea = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if ((coll.transform.tag == "Trail" || coll.transform.name == "Start") && hasStartedTheTrail)
        {
            trailCountHelper--;
        }
    }

    // Update is called once per frame
    void Update () {
        DragObject();
    }


    private void DragObject()
    {
        if (isDroppedinCorrectArea)
        {
            UIManager.instance.ShowInfoPanel(objectName, objectInfo, true);
            this.enabled = false;
        }
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
                        isDraging = true;
                        transform.position = new Vector3(transform.position.x, transform.position.y + 40, transform.position.z);
                    }
                }
            }
            if ((Input.GetTouch(i).phase == TouchPhase.Moved || Input.GetTouch(i).phase == TouchPhase.Stationary) && isDraging)
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
                    if (hasStartedTheTrail)
                    {
                        if (trailCountHelper < 1)
                        {
                            isDraging = false;
                            transform.position = startingPosition;
                            hasStartedTheTrail = false;
                        }
                    }
                    else
                    {
                        if(trailCountHelper > 0)
                        {
                            isDraging = false;
                            transform.position = startingPosition;
                            trailCountHelper = 0;
                        }
                    }
                }
            }
            if((Input.GetTouch(i).phase == TouchPhase.Ended))
            {
                isDraging = false;
                transform.position = startingPosition;
            }
        }
    }
}
