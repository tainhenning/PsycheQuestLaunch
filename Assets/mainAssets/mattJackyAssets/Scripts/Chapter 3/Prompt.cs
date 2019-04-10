using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompt : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update

    void Start()
    {
        text = transform.GetChild(0).GetComponent<Text>();
    }

   public void PromptState(int state)
    {
        if (state == 0)
            text.text = "Tap the screen to select the trajectory.";
        else if (state == 1)
            text.text = "Tap the screen to select the power. Aim for the middle section.";
        else if (state == 2)
            text.text = "Tap the screen to launch the satellite.";
        else if (state == 3)
            text.text = "Try again. Remember to aim for the middle section.";
        else
            text.text = "";
    }
}
