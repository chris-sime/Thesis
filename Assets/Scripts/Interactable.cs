using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    [SerializeField]
    protected string objectName;

    [SerializeField]
    [TextArea(3, 10)]
    protected string objectInfo;

    [SerializeField]
    protected GameObject InfoPanel;
    [SerializeField]
    protected GameObject ContinueButton;
    [SerializeField]
    protected GameObject CloseButton;

    protected Text nameUI;
    protected Text infoUI;

    protected ToggleEnable infoPanelEnabler;
    protected ToggleEnable continueButtonEnabler;
    protected ToggleEnable closeButtonEnabler;

    void Start()
    {

    }
   
}
