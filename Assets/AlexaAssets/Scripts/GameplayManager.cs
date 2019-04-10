using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    public GameObject panel; //pause panel
    public Button pauseButton;
    public Text highScore;

    void Start()
    {
        Time.timeScale = 1.0f;
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()    {
    }

    //***** Pause Menu *****//
    public void PauseGame()
    {
        Time.timeScale = 0f;
        //panel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        //panel.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    //***** Back To Map *****//
    // FOR TAIN//
    public void MainMenu()
    {
        SceneManager.LoadScene("JourneyMap"); //to swap
    }

    //***** Game Over Menu *****//
    public void GameOver()
    {
        SceneManager.LoadScene("GameOverGame2");
        highScore.text = "" + Score.instance.GetHighScore();
    }

    public void ReplayGame(string scene)
    {
        SceneManager.LoadScene(scene);  // will take scene input depending on level 
    }

    public void IfGameIsOver(int score)
    {
        if (score > Score.instance.GetHighScore())
        {
            Score.instance.SetHighScore(score);
        }
    }

    public void NextLevel(string scene)
    {
        SceneManager.LoadScene(scene);  // will take scene input depending on level 
    }
}
