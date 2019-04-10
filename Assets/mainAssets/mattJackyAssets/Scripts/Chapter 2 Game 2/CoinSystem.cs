using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour {

    private SatelliteBehavior sb;

    // Use this for initialization
    void Start () {
        sb = FindObjectOfType<SatelliteBehavior>();
    }
	
	void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.CompareTag("Player"))
       {
            sb.IncrementCoins();
            Destroy(gameObject);
       }
    }
}
