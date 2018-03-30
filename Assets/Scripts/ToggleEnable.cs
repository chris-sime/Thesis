using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEnable : MonoBehaviour
{

    [SerializeField] bool startEnabled = false;
    private void Awake()
    {
        if (!startEnabled) gameObject.SetActive(false);
    }

    public void Enable()
    {
        Time.timeScale = 0;
        Debug.Log("Time scale is set to 0");
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        Time.timeScale = 1;
        Debug.Log("Time scale is set to 1");
        gameObject.SetActive(false);
    }

    public void EnableNoPause()
    {
        gameObject.SetActive(true);
    }

    public void DisableNoPause()
    {
        gameObject.SetActive(false);
    }


}
