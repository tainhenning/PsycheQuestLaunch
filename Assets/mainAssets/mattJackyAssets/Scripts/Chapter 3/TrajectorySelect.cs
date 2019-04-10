using UnityEngine;


/**
 * Created by: Matthew Lillie
 * Date: February 8th, 2019
 * 
 * Handles the trajectory selection process for the satellite to be "launched" into the orbit of the asteroid. 
 *
 */
public class TrajectorySelect : MonoBehaviour
{
    private float rotationSpeed = 30f;
    private float rotationAngle = 60f;
    public Transform pivotTransform;
    public float startingRotation;
    public bool stillMoving = true;
    private bool positiveMovement = false;
    public float currentAngle;

    void Start()
    {
        startingRotation = pivotTransform.eulerAngles.z;
        currentAngle = startingRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (stillMoving)
        {
            if (positiveMovement)
            {
                currentAngle = Mathf.MoveTowards(currentAngle, startingRotation + rotationAngle,
                                rotationSpeed * Time.deltaTime);
                if (currentAngle >= startingRotation + rotationAngle)
                {
                    positiveMovement = false;
                }
                pivotTransform.eulerAngles = new Vector3(0, 0, currentAngle);
            }
            else
            {
                currentAngle = Mathf.MoveTowards(currentAngle, startingRotation - rotationAngle,
                                rotationSpeed * Time.deltaTime);
                if (currentAngle <= startingRotation - rotationAngle)
                {
                    positiveMovement = true;
                }
                pivotTransform.eulerAngles = new Vector3(0, 0, currentAngle);
            }

        }
    }

    public void selected()
    {
        transform.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CH3-arrowgry");
    }

    public void disappear()
    {
        transform.GetComponent<SpriteRenderer>().enabled = false;
    }
}