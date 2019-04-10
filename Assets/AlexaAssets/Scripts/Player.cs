using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float VelocityPerJump = 2;
    public float XSpeed = 1;

//    public AudioSource audioScource;
//    public AudioClip FlyAudioClip, DeathAudioClip, ScoredAudioClip;

    public float RotateUpSpeed = 0.5f, RotateDownSpeed = 0.5f;

    public int score;
    public Text ScoreText;

    void Start() {
  
    }

    PlayerYAxisTravelState playerYAxisTravelState;
    enum PlayerYAxisTravelState
    {
        GoingUp, GoingDown
    }

    Vector3 playerRotation = Vector3.zero;

    /**
     * Update is called every frame
     * Boosts player upward if click is registered
     **/
    void Update()
    {
        MovePlayerOnXAxis();
        if (WasTouchedOrClicked())
        {
            BoostOnYAxis();
        }
        if (score > 5) {
            progressionStatic.End = true;
        }
    }
    /**
     * Calls for rotation of player object 
     **/
    void FixedUpdate()
    {
        FixPsycheRotation();
    }

    /**
     * Method registering user interaction to move player
     * */
    bool WasTouchedOrClicked()
    {
        if (Input.GetButtonUp("Jump") || Input.GetMouseButtonDown(0) ||
            (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)) //unsure which command is needed for cross-platform
            return true;
        else
            return false;
    }
    //move player to the right
    void MovePlayerOnXAxis()
    {
        transform.position += new Vector3(Time.deltaTime * XSpeed, 0, 0);
    }

    void BoostOnYAxis()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, VelocityPerJump);
     //   GetComponent<AudioSource>.PlayOneShot(FlyAudioClip);
    }

    /**
     * Called by FixedUpdate for player rotatation
     **/
    private void FixPsycheRotation()
    {
        if (GetComponent<Rigidbody2D>().velocity.y > 0) playerYAxisTravelState = PlayerYAxisTravelState.GoingUp;
        else playerYAxisTravelState = PlayerYAxisTravelState.GoingDown;

        float degreesToAdd = 0;

        switch (playerYAxisTravelState)
        {
            case PlayerYAxisTravelState.GoingUp:
                degreesToAdd = 6 * RotateUpSpeed;
                break;
            case PlayerYAxisTravelState.GoingDown:
                degreesToAdd = -3 * RotateDownSpeed;
                break;
            default:
                break;
        }
    }
   
    /****************************************************
     * Collision Handlers
     * The following two methods check for collisions with 
     * obstacles, borders, and coins. 
     * ***************************************************/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if player collides with a coin, score is incremented and coin object is destroyed
        if (collision.tag == "Coin")
        {
      //      audioSource.PlayOneShot(ScoredAudioClip);
            score++;
            Debug.Log("Coin Count");
            Destroy(collision.gameObject);
        }
       else if (collision.tag == "Obstacle")
        {
            PlayerDies();
            // GetComponent<Rigidbody2D>().transform.position = new Vector2(-2, 2);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            PlayerDies();
            // GetComponent<Rigidbody2D>().transform.position = new Vector2(-2, 2);
        }
       else if (collision.gameObject.tag == "Flag")
        {
            SceneManager.LoadScene("LevelWon");
        } 
    }

    void PlayerDies()
    {
        GetComponent<Rigidbody2D>().transform.position = new Vector2(-2, 2);
     //   SceneManager.LoadScene("Intro");
    //    audioSource.PlayOneShot(DeathAudioClip);
        ScoreText.text = " " + this.score;
   //     Debug.Log("Game Over!!");
   //     GameplayManager.instance.GameOver();
    //    GameplayManager.instance.IfGameIsOver(score);
 //       StartCoroutine(StopMoving());
    }
    IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
    }
}
