using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManagera : MonoBehaviour
{
    public static IntroManagera instance;

    void Awake()
    {
        Time.timeScale = 1f;
        if (instance == null)
        {
            instance = this;
        }
    }
    
    void Start() {  
    }
    void Update() {  
    }

    public void PlayGame(string scenename)
    {
        SceneManager.LoadScene("level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
