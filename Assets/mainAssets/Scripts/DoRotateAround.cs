using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoRotateAround : MonoBehaviour
{

    public float speed;
    public Transform target;
    public int goForward;
    public Button switcher;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    public Transform[] listOfAsteroids;
    private void Start()
    {
        if(switcher) {
            switcher.onClick.AddListener(switchToOrbit);
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1.0f;
        }
    }
    void FixedUpdate()
    {
        if(goForward == 0)
        {
            transform.RotateAround(target.position, zAxis, speed);
        }
        else
        {
            transform.Translate(0, Time.deltaTime * 1, 0);
        }
    }
    void switchToOrbit ()
    {
        if(goForward == 1)
        {
            Vector3 closest = target.position;
            Transform close = target;
            for (int i = 0; i < listOfAsteroids.Length; i++)
            {
                Vector3 dist = transform.position - listOfAsteroids[i].position;
                Transform temp = listOfAsteroids[i];
                if (dist.magnitude < closest.magnitude)
                {
                    closest = dist;
                    close = temp;
                }
            }
            print(closest.magnitude);
            if(closest.magnitude > 2) {
                return;
            }
            target = close;
            goForward = 0;
            if (transform.position.x >= target.position.x)
            {
                speed = 1;
            }
            else
            {
                speed = -1;
            }
        }
        else
        {
            goForward = 1;
        }

    }
}
