using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebooHandler : MonoBehaviour {

    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpForce;

    private Rigidbody2D rb;
    private const float groundRadius = .2f;
    private bool facingRight = false;
    private PowerUp powerUp;

    // Use this for initialization
    void Start () {
        powerUp = FindObjectOfType<PowerUp>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        if(IsGrounded())
        {
            rb.velocity = Vector2.up * (jumpForce * powerUp.getEnemySpeed());
        }

        float xSpeed = (facingRight ? movementSpeed : -movementSpeed) * powerUp.getEnemySpeed();
        float ySpeed = rb.velocity.y * powerUp.getEnemySpeed();
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    private bool IsGrounded()
    {
        //Will check all possible colliders that are overlapping with the given ground check position and what ground has been given to be.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            //If the object is not the this object
            if (colliders[i].gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider != null && !col.collider.CompareTag("Player"))
        {
            //Check where we got hit
            foreach (ContactPoint2D point in col.contacts)
            {
                if (point.normal.x > 0)
                {
                    if (!facingRight)
                    {
                        facingRight = true;
                        Vector3 theScale = transform.localScale;
                        theScale.x *= -1;
                        transform.localScale = theScale;
                    }
                }
                else if (point.normal.x < 0)
                {
                    if(facingRight)
                    {
                        facingRight = false;
                        Vector3 theScale = transform.localScale;
                        theScale.x *= -1;
                        transform.localScale = theScale;
                    }
                }
            }
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
