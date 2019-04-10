using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterCoin : MonoBehaviour
{
    public Transform satellite;
    private Transform thisTransform;
    public coinCount coin;

    private void Start()
    {
        thisTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (satellite.position.x + 0.25 > thisTransform.position.x && satellite.position.x - 0.25 < thisTransform.position.x)
        {
            if (satellite.position.y + 0.25 > thisTransform.position.y && satellite.position.y - 0.25 < thisTransform.position.y)
            {
                coin.coins++;
                Destroy(gameObject);
            }
        }
    }
}
