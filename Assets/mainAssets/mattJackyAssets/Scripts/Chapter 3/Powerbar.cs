using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/**
 * Created by: Matthew Lillie
 * Date: February 7th, 2019
 * 
 * Handles the powerbar sliders automatically moving as well as stopping the powerbar via a click. 
 *
 */
public class Powerbar : Slider, IPointerDownHandler
{
    public bool stillMoving = true;

    private float growthRate = 0.75f; // Determines how fast the bar will be moving
    private bool goingUp = true;
    void LateUpdate()
    {
        if (stillMoving)
        {
            if (goingUp)
            {
                value = Mathf.MoveTowards(value, maxValue, growthRate * Time.deltaTime);
                if (value >= maxValue)
                {
                    goingUp = false;
                }

            }
            else
            {
                value = Mathf.MoveTowards(value, minValue, growthRate * Time.deltaTime);
                if (value <= minValue)
                {
                    goingUp = true;
                }
            }
        }
    }
}
