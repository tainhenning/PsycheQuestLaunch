using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public static IntroManager instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update() {         }
    
    // simple code to toggle between screens
    public void EarthScreen()
    {
        SceneManager.LoadScene("Earth");
    }
    public void SatelliteScreen()
    {
        SceneManager.LoadScene("Satellite");
    }
    public void AsteroidScreen()
    {
        SceneManager.LoadScene("Asteroid");
    }
}
