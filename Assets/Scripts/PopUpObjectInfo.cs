using UnityEngine;
using UnityEngine.UI;

public class PopUpObjectInfo : Interactable {

    public GameObject InfoPanel;

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
    }
	
	// Update is called once per frame
	void Update () {  
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2, 0));
        
        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.transform;
            if(objectHit == this.transform)
            {
                countdown -= Time.deltaTime;
                if(countdown < 0)
                {
                    Debug.Log(objectHit.name);
                    InfoPanel.GetComponentsInChildren<Text>()[0].text = _name;
                    InfoPanel.GetComponentsInChildren<Text>()[1].text = _info;
                    InfoPanel.SetActive(true);
                }
            }
        }
        else
        {
            countdown = hoverTimeUntilPopUp;
            InfoPanel.SetActive(false);
        }
        
    }
}
