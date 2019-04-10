using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandling : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject helperMenu;

    public void Start()
    {
        pauseMenu.SetActive(false);

        // Show robby the robot on level 1 only.
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            helperMenu.SetActive(true);
            Time.timeScale = 0;
        } else
        {
            helperMenu.SetActive(false);
        }
    }

    public void Pause()
    {
        // Pause the game.
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        // Unpause the game.
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void FinishHelp()
    {
        //Closes the helper menu and unpauses the game.
        helperMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
