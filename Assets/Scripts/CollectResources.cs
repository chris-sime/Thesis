using UnityEngine;

public class CollectResources : MonoBehaviour {

    [SerializeField] PlayerResources resources;
    [Space]
    public int ammount = 10;


    Transform objectHit;
    RaycastHit hit;

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
                    if (objectHit.tag == "Wood") resources.wood += ammount;
                    if (objectHit.tag == "Rock") resources.rock += ammount;
                    if (objectHit.tag == "Gold") resources.gold += ammount;
                    //Update Resources UI
                    Destroy(gameObject);
                }
            }
        }
    }
}
