using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    [SerializeField]
    public string _name;

    [SerializeField]
    [TextArea(3, 10)]
    public string _info;
}
