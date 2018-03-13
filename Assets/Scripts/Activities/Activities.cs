using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activities : MonoBehaviour {

    [Header("Info Panel")]
    public GameObject InfoPanel;
    public GameObject ContinueButton;
    public GameObject CloseButton;
    [Space]
    [Header("Prompt Panel")]
    public GameObject PromptPanel;
    public GameObject OkButton;
    [TextArea][SerializeField] protected string[] Prompts;

    [Space]
    [Header("Activity Objects")]
    public GameObject[] GameObjects;


    protected ToggleEnable infoPanelEnabler;
    protected ToggleEnable continueButtonEnabler;
    protected ToggleEnable closeButtonEnabler;

    protected ToggleEnable promptPanelEnabler;
    protected ToggleEnable okButtonEnabler;

    protected ActivityManager activityManager;
    protected string promptInfo;

    private void Start()
    {
        activityManager = FindObjectOfType<ActivityManager>();
    }
}
