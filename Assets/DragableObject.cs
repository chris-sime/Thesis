using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : MonoBehaviour {

    Vector3 startingPosition;
    public GameObject planeDragHelper;
    Transform objectHit;
    RaycastHit hit;

    bool isDraging = false;
    int layerMask = 1 << 8;

    Plane plane = new Plane(Vector3.up, Vector3.zero);

    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

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
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    objectHit = hit.transform;
                    if (objectHit == planeDragHelper.transform)
                    {
                        transform.position = Vector3.Lerp(transform.position, hit.point, Time.deltaTime * 2);
                    }
                }

            }
            if (Input.GetTouch(i).phase == TouchPhase.Ended && isDraging)
            {
                isDraging = false;
                transform.position = startingPosition;
            }
        }
    }
}
