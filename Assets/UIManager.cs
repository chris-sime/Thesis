using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [Header("INFO PANEL")]
    public ToggleEnable infoPanel;
    public Text infoPanelName;
    public Text infoPanelInfo;
    public Button continueButton;
    public Button closeButton;

    [Space]
    [Header("PROMPT PANEL")]
    public ToggleEnable promptPanel;
    public Text promptPanelName;
    public Text promptPanelInfo;
    public Button okButton;
    [Space]
    public ToggleEnable promptBubble;

    [Space]
    [Header("General")]
    public Image indicator;

    public static UIManager instance = null;
    // Use this for initialization
    void Awake() {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {

    }
    public void FillIndicator(float timeToFill, float currentTime)
    {
        Debug.Log(currentTime / timeToFill);
        indicator.fillAmount = currentTime / timeToFill;

    }
    public void ResetIndicator(){
        indicator.fillAmount = 0;
    }


    public void ShowInfoPanel(string name, string info, bool isCorrect)
    {
        infoPanelName.text = name;
        infoPanelInfo.text = info;
        closeButton.enabled = true;
        if (isCorrect)
        {
            continueButton.enabled = true;
        }
        infoPanel.Enable();
        promptBubble.Disable();
        ResetIndicator();
    }
    public void HideInfoPanel()
    {
        continueButton.enabled = false;
        closeButton.enabled = false;
        infoPanel.Disable();
        promptBubble.Enable();
        ResetIndicator();
    }

    public void ShowPromptPanel(string name, string info)
    {
        promptPanelName.text = name;
        promptPanelInfo.text = info;
        promptPanel.Enable();
        ResetIndicator();
    }
    public void HidePromptPanel()
    {
        infoPanel.Disable();
        ResetIndicator();
    }
}
