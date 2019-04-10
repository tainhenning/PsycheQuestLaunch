using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float movementSpeed = 12.5f;

	// Use this for initialization
	void Start () {

        rb.velocity = transform.right * movementSpeed;
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject);
        }

        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
