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
}
