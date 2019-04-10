using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeembaHandler : MonoBehaviour {

    private Rigidbody2D rb;

    [SerializeField]
    private bool facingRight = false;

    [SerializeField]
    private float movementSpeed;

    private PowerUp powerUp;

	void Start () {
        powerUp = FindObjectOfType<PowerUp>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        //Ensure it is always moving on fixed update.
        float xSpeed = (facingRight ? movementSpeed : -movementSpeed) * powerUp.getEnemySpeed();
        float ySpeed = rb.velocity.y * powerUp.getEnemySpeed();
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
 

        if (col.collider != null && !col.collider.CompareTag("Player"))
        {
            //Check where we got hit
            foreach (ContactPoint2D point in col.contacts)
            {
                if(point.normal.x > 0)
                {
                    if(!facingRight)
                    {
                        facingRight = true;
                        Vector3 theScale = transform.localScale;
                        theScale.x *= -1;
                        transform.localScale = theScale;
                    }

                } else if(point.normal.x < 0)
                {
                    if (facingRight)
                    {
                        facingRight = false;
                        Vector3 theScale = transform.localScale;
                        theScale.x *= -1;
                        transform.localScale = theScale;
                    }

                }
            }
        } else if(col.collider.CompareTag("Player"))
        {
            //TOdO?
            //print("hititng playeR?");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        //We hit an invisble barrier, so move the other way
        if (collider.CompareTag("Barrier"))
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

}
