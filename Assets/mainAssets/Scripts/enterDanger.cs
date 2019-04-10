using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterDanger : MonoBehaviour
{
    public GameObject endScreen;
    public Transform satellite;
    public GameObject satelliteObj;
    private Transform thisTransform;
    public int width;
    public int height;

    private void Start()
    {
        thisTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (satellite.position.x + 1 > thisTransform.position.x - width/2 && satellite.position.x - 1 < thisTransform.position.x + width/2)
        {
            if (satellite.position.y + 1 > thisTransform.position.y - height/2 && satellite.position.y - 1 < thisTransform.position.y + height/2)
            {
                endScreen.SetActive(true);
                Destroy(satelliteObj);
            }
        }
    }
}
