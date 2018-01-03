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
        countdown = hoverTimeUntilPopUp;
        cam = FindObjectOfType<Camera>();

        nameUI = InfoPanel.GetComponentsInChildren<Text>()[0];
        infoUI = InfoPanel.GetComponentsInChildren<Text>()[1];

        infoPanelEnabler = InfoPanel.GetComponent<ToggleEnable>();
        continueButtonEnabler = ContinueButton.GetComponent<ToggleEnable>();
        closeButtonEnabler = CloseButton.GetComponent<ToggleEnable>();
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
                    if (isCorrectObject) //if it is the object we are looking for enable the ui and the continue
                    {
                        infoPanelEnabler.Enable();
                        continueButtonEnabler.Enable();
                        closeButtonEnabler.Enable();
                    }
                    else if(!isCorrectObject) //otherwise we enable only the close button to continue searching for the right object 
                    {
                        infoPanelEnabler.Enable();
                        closeButtonEnabler.Enable();
                    }
                }
            }
        }
        else
        {
            countdown = hoverTimeUntilPopUp;
            //infoPanelEnabler.Disable();
            //continueButtonEnabler.Disable();
            //closeButtonEnabler.Disable();
        }

    }
}
