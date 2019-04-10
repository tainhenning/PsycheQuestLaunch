using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthManager : MonoBehaviour
{
    public static EarthManager instance;

    public GameObject EarthInfo, SelectionMenu, HelpPanel;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()   {       }

    // toggle back and forth between info displaying, and not
    // press on "Earth" text ontop of textbox to toggle downward
    public void GetInfo()
    {
        EarthInfo.gameObject.SetActive(true);
    }
    public void CloseInfo()
    {
        EarthInfo.gameObject.SetActive(false);
    }

     // Select item menu
    public void SelectObject()
    {
        SelectionMenu.gameObject.SetActive(true);
    }

    // Help info toggle 
    public void GetHelp()
    {
        HelpPanel.gameObject.SetActive(true);
    }
    public void CloseHelp()
    {
        HelpPanel.gameObject.SetActive(false);
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Intro");
    }
}
