using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropObject : Interactable
{

    Vector3 startingPosition;
    public GameObject planeDragHelper;
    Transform objectHit;
    RaycastHit hit;

    [SerializeField]
    private GameObject dropArea;

    bool isDraging = false;
    bool isDroppedinCorrectArea = false;

    LayerMask layerMask = 1 << 8;

    // Use this for initialization
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        DragObject();
        ShowName();
    }

    private void ShowName()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.transform;
            if (objectHit == transform)
            {
                UIManager.instance.ShowNameHeader(objectName);
            }
            if (objectHit == planeDragHelper.transform)
            {
                UIManager.instance.HideNameHeader();
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.tag == "DropArea")
        {
            isDroppedinCorrectArea = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.transform.tag == "DropArea")
            isDroppedinCorrectArea = false;
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
                }
            }
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                if (isDroppedinCorrectArea && isCorrectAnswer)
                {
                    UIManager.instance.ShowInfoPanel(objectName, objectInfo, isCorrectAnswer);
                }
                else if (isDraging)
                {
                    isDraging = false;
                    transform.position = startingPosition;
                }
            }
        }
    }
}
