using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{

    public Dropdown dropdown;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    public void LoadActivity()
    {
        PlayerPrefs.SetInt("ActivitiesCompleted", dropdown.value);
        SceneManager.LoadScene(1);
    }
}
