using UnityEngine;
using UnityEngine.UI;

public class ObjectInfo : MonoBehaviour {

    public string _name;
    public string _info;

    public GameObject InfoPanel;

    Camera cam;  
    float countdownTime = 2f;

	// Use this for initialization
	void Start () {
        
        cam = FindObjectOfType<Camera>();
    }
	
	// Update is called once per frame
	void Update () {

        Transform objectHit;       
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2f + 20, Screen.height/2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.transform;
            if(objectHit == this.transform)
            {
                countdownTime -= Time.deltaTime;
                if(countdownTime < 0)
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
            countdownTime = 2f;
            InfoPanel.SetActive(false);
        }
        
    }
}
