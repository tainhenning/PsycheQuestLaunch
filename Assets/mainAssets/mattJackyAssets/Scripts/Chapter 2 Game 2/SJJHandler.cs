using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SJJHandler : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

    private Rigidbody2D rb;

    private PowerUp powerUp;

    //Use this for initialization 
    void Start()
    {
        powerUp = FindObjectOfType<PowerUp>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {   
        float xSpeed = -movementSpeed * powerUp.getEnemySpeed();
        float ySpeed = rb.velocity.y * powerUp.getEnemySpeed();
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider != null && !col.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
