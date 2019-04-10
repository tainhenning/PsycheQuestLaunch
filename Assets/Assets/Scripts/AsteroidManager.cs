using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidManager : MonoBehaviour
{
    public static AsteroidManager instance;

    public GameObject AsteroidInfo, SelectionMenu, HelpPanel;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update() { }

    // toggle back and forth between info displaying, and not
    // press on help panel to toggle downward
    public void GetInfo()
    {
        AsteroidInfo.gameObject.SetActive(true);
    }
    public void CloseInfo()
    {
        AsteroidInfo.gameObject.SetActive(false);
    }

    // Select item menu
    public void SelectObject()
    {
        SelectionMenu.gameObject.SetActive(true);
    }

    // Help info toggle 
    // press on the help object to toggle downward 
    public void GetHelp()
    {
        HelpPanel.gameObject.SetActive(true);
    }
    public void CloseHelp()
    {
        HelpPanel.gameObject.SetActive(false);
    }

    // home button 
    public void GoHome()
    {
        SceneManager.LoadScene("Intro");
    }
}

