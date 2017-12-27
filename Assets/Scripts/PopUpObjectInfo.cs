using UnityEngine;
using UnityEngine.UI;


public class PopUpObjectInfo : Interactable {

    Camera cam;  
    [SerializeField]
    float hoverTimeUntilPopUp = 1.5f;
    float countdown;

    Transform objectHit;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
        countdown = hoverTimeUntilPopUp;
        cam = FindObjectOfType<Camera>();

        nameUI = InfoPanel.GetComponentsInChildren<Text>()[0];
        infoUI = InfoPanel.GetComponentsInChildren<Text>()[1];

        infoPanelEnabler = InfoPanel.GetComponent<ToggleEnable>();
        continueButtonEnabler = ContinueButton.GetComponent<ToggleEnable>();
    }
	
	// Update is called once per frame
	void Update () {  
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2, 0));
        
        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.transform;
            if(objectHit == this.transform)
            {
                nameUI.text = objectName;
                infoUI.text = objectInfo;
                countdown -= Time.deltaTime;
                if(countdown < 0)
                {
                    infoPanelEnabler.Enable();
                    continueButtonEnabler.Enable();
                }
            }
        }
        else
        {
            countdown = hoverTimeUntilPopUp;
            infoPanelEnabler.Disable();
            continueButtonEnabler.Disable();
        }
        
    }
}
