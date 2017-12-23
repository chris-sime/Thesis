using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEnable : MonoBehaviour {

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
