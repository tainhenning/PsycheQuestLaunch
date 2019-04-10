using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SatelliteBehaviorCH3 : MonoBehaviour
{

    // Enum to represent the current game state.
    private enum GameState
    {
        TRAJECTORY_SELECTION,
        POWER_SELECTION,
        LAUNCH,
        LAUNCHED
    }

    private Vector2 LAUNCH_VELOCITY = new Vector2(20f, 80f); // TODO take trajectory/powerbar values
    private Vector2 INITIAL_POSITION = Vector2.zero;
    private Vector2 GRAVITY = new Vector2(0f, -240f); //TODO
    private TrajectorySelect traj;
    private Powerbar powerbar;
    private Rigidbody2D rb;
    private Prompt prompt;
    private Audio audio;
    private GameState currentState;

    [SerializeField]
    private GameObject helperMenu;

    // Start is called before the first frame update
    void Start()
    {
        traj = FindObjectOfType<TrajectorySelect>();
        powerbar = FindObjectOfType<Powerbar>();
        prompt = FindObjectOfType<Prompt>();
        audio = FindObjectOfType<Audio>();

        rb = GetComponent<Rigidbody2D>();
        // So it cannot move
        rb.gravityScale = 0;
        // Initial state
        currentState = GameState.TRAJECTORY_SELECTION;

        //Helper menu initially.
        helperMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {

        // No need to update if paused
        if(Time.timeScale == 0)
        {
            return;
        }



        if (Input.GetMouseButtonDown(0)) // If the screen was clicked / tapped
        {
            switch (currentState)
            {
                case GameState.TRAJECTORY_SELECTION:
                    traj.stillMoving = false;
                    traj.selected();
                    audio.playClip(0);
                    prompt.PromptState(1);
                    currentState = GameState.POWER_SELECTION;
                    break;
                case GameState.POWER_SELECTION:
                    audio.playClip(0);
                    if (powerbar.value < 0.3 || powerbar.value > 0.7)
                    {
                        prompt.PromptState(3);
                        powerbar.stillMoving = true;
                    }
                    else
                    {
                        prompt.PromptState(2);
                        powerbar.stillMoving = false;
                        currentState = GameState.LAUNCH;
                    }
                    //print(powerbar.value);
                    break;
                case GameState.LAUNCH:
                    traj.disappear();
                    prompt.PromptState(4);
                    currentState = GameState.LAUNCHED;
                    audio.playClip(1);
                    break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentState == GameState.LAUNCHED)
        {
            float powerValue = powerbar.value;
            float angleValue = (traj.currentAngle - traj.startingRotation);
            rb.isKinematic = true;
            rb.gravityScale = 1;
            Vector2 vel = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * angleValue), Mathf.Cos(Mathf.Deg2Rad * angleValue)) * powerValue * 2f;
            rb.MovePosition(rb.position + vel * Time.fixedDeltaTime);
        }    
    }

    public void FinishHelper()
    {
        helperMenu.SetActive(false);
        prompt.PromptState(0);
        Time.timeScale = 1f;
    }

    private Vector2 CalculatePosition(float elapsedTime)
    {
        return GRAVITY * elapsedTime * elapsedTime * 0.5f +
                   LAUNCH_VELOCITY * elapsedTime + INITIAL_POSITION;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Barrier")
        {
            SceneManager.LoadScene("GameOverGame2");
        }
        else
        {
            SceneManager.LoadScene("CompleteGame2");
        }
    }
}
