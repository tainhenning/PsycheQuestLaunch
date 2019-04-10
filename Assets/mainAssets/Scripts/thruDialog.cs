using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thruDialog : MonoBehaviour
{
    private Button thisButton;
    public int amountOfClicks;
    private int currentClicks = 0;

    private void Start()
    {
        Time.timeScale = 0;
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(clicker);
    }
    private void clicker()
    {
        currentClicks++;
        if (currentClicks >= amountOfClicks)
        {
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }
    }
}
