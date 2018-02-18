using UnityEngine;
using UnityEngine.UI;


public class PopUpObjectInfo : Interactable {

    [SerializeField]
    private bool isCorrectObject = true;

    [SerializeField]
    float hoverTimeUntilPopUp = 1.5f;
    float countdown;

    Transform objectHit;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
        countdown = 0;  
    }
	
	// Update is called once per frame
	void Update () {  
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2, 0));
        
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
            while (countdown > 0)
            {
                countdown = 0;
                UIManager.instance.ResetIndicator();
            }
            
        }
    }
}
