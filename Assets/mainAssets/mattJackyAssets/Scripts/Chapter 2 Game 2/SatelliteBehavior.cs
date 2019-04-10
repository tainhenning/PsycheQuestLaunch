using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SatelliteBehavior : MonoBehaviour {

    //Private fields which will not be visible in the inspector
    private Audio audio;
    private Rigidbody2D rb;
    private const float groundRadius = .2f;
    private bool facingRight = true;
    private int currentJumps = 0;
    private bool grounded = true;
    private bool invincible = false;

    public float playerGrowth = 1f;
    public int PowerUpMode = 0;
    public int coins = 0;
    public int multiplier = 1;
    public int numberOfJumps = 2;

    public Transform shootingPosition;

    //Serialized fields (appear in the Unity inspector)
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float movementSpeed = 1.5f;
    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private int unlocks;

    // Use this for initialization
    void Start()
    {
        audio = FindObjectOfType<Audio>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // No need to check for updates if game is paused.
        if (Time.timeScale == 0)
        {
            return;
        }

        grounded = IsGrounded();

        //Checking for jumps
        if (grounded)
        {
            //We are crounded so reset the number of multiple jumps that can occurr
            currentJumps = 0;
            //If we are grounded, then we are always facing right, so ensure this is true
            facingRight = true;
            if (transform.localScale.x < 0)
            {

                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }

            //Normal on ground jump check
            if (Input.GetMouseButtonDown(0) && currentJumps < numberOfJumps)
            {
                audio.playClip(2);
                rb.velocity = Vector2.up * jumpForce;
                currentJumps++;
            }
        }
        else
        {
            //Check for wall jumping and multiple jumps
            CheckJump();
        }
    }

    //Better for handling physics based changes
    void FixedUpdate()
    {
        //Ensure we are always moving in horizontal direction
        rb.velocity = new Vector2((facingRight ? movementSpeed : -movementSpeed) * 10f, rb.velocity.y);
    }

    //Checks for both wall jumping and multiple jumps (within the air already)
    private void CheckJump()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 1.5f);
        if (Input.GetMouseButtonDown(0))
        {
           
            //Checking for wall jumping
            if (hit.collider != null && 
                !hit.collider.CompareTag("Block") && !hit.collider.CompareTag("Barrier"))  
            {
                audio.playClip(2);
                print(hit.collider.tag);
                rb.velocity = new Vector2(hit.normal.x * movementSpeed * 10f, 7f);
                //Switch the direction we are facing.
                facingRight = !facingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                currentJumps = 0;
            }
            //Handling multiple jumps (if we are not grounded and we are not going to hit a wall)
            else if (currentJumps < numberOfJumps)
            {
                audio.playClip(2);
                rb.velocity = Vector2.up * jumpForce * 1.5f;
                currentJumps++;
            }


        }
    }

    //Checks to see if the Player is currently on the ground
    private bool IsGrounded()
    {
        //Will check all possible colliders that are overlapping with the given ground check position and what ground has been given to be.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            //If the object is not the player object
            if (colliders[i].gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Make sure there is a collider and that the tag for the collider is that of an enemy
        if (col.collider != null && col.collider.CompareTag("Enemy"))
        {
            //TODO make smol boi/die/restart game
            foreach (ContactPoint2D point in col.contacts)
            {
                print(point.normal.y);
                if (point.normal.y <= 0.9f && !invincible)
                {
                    audio.playClip(1);
                    TakeHit(col.collider.gameObject);
                    break;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Trigger and enemy = hit their head, which means they and we jump higher
        if(collider.CompareTag("Enemy"))
        {
            rb.velocity = Vector2.up * jumpForce / 1.5f;
            Destroy(collider.gameObject);
        } else if (collider.CompareTag("End Flag"))
        {
            if (unlocks == 2) {
                progressionStatic.Game2_2 = true;
            } else if (unlocks == 3) {
                progressionStatic.Game2_3 = true;
            } else if (unlocks == 4) {
                progressionStatic.Game3 = true;
            }

            SceneManager.LoadScene("CompleteGame2");
        }
        else if (collider.tag == "Bound")
        {
            SceneManager.LoadScene("GameOverGame2");
        }
    }

    public void TakeHit(GameObject hitFrom)
    {
        if(PowerUpMode == 1 || PowerUpMode == 2) //We are grown or have a flight
        {
            PowerUpMode = 0;
            size(-playerGrowth);
            multiplier = 1;
            numberOfJumps = 2;
            StartCoroutine(TookHitTimer(hitFrom));

        } else // We have no power up or anything.
        {
            SceneManager.LoadScene("GameOverGame2");
        }
    }

    IEnumerator TookHitTimer(GameObject hitFrom)
    {
        invincible = true;
        if (hitFrom != null)
        {
            foreach (Collider2D colliders in hitFrom.GetComponents<Collider2D>())
            {
                colliders.enabled = false;
            }
        }
        StartCoroutine(Flash());
        yield return new WaitForSeconds(3f);
        invincible = false;
        if (hitFrom != null)
        {
            foreach (Collider2D colliders in hitFrom.GetComponents<Collider2D>())
            {
                colliders.enabled = true;
            }
        }
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 8; i++)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void size(float mult)
    {
        StartCoroutine(ChangeScale(0.8f, mult)); 
    }

    IEnumerator ChangeScale(float time, float newScale)
    {
        Vector3 originalScale = transform.localScale;
        Vector3 destinationScale = transform.localScale * (newScale < 0 ? 1 / -newScale : newScale);

        float currentTime = 0.0f;

        do
        {
            transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }

    public int getMode()
    {
        return PowerUpMode;
    }
    public void setMode(int type)
    {
        PowerUpMode = type;
    }
    public int getCoins()
    {
        return coins;
    }

    public void IncrementCoins()
    {
        coins += multiplier;
        audio.playClip(0);
    }
}
