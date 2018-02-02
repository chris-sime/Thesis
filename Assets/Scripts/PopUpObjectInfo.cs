using UnityEngine;
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
        countdown = 0;
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
                UIManager.instance.FillIndicator(hoverTimeUntilPopUp, countdown);
                countdown += Time.deltaTime;
                if(countdown >= hoverTimeUntilPopUp)
                {
                    UIManager.instance.ShowInfoPanel(objectName, objectInfo, isCorrectObject);
                }
            }
        }
        else
        {
            while (countdown >= 0)
            {
                countdown -= Time.deltaTime;
                UIManager.instance.FillIndicator(hoverTimeUntilPopUp, countdown);
            }
            
        }
    }
}
