using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private float enemySpeed = 1f;
    private int multiplePointMultiplier = 2;

    private float powerUpTimer;
    private SatelliteBehavior cs;
    private GameObject projectile;
    private float shotIntervalTime = 0.5f;

    private Audio audio;

    // Use this for initialization
    void Start()
    {
        projectile = (GameObject) Resources.Load("Projectile", typeof(GameObject));
        audio = FindObjectOfType<Audio>();
        cs = FindObjectOfType<SatelliteBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cs.getMode() == 2)
        {
            powerUpTimer -= Time.deltaTime;
            //print(powerUpTimer);
            if (powerUpTimer <= 0)
            {
                cs.setMode(1); // Set the mode back to just grown
                cs.multiplier = 1;
                cs.numberOfJumps = 2;
                enemySpeed = 1f;
            }
        }
    }

    public void Activation(bool flying, bool invincible, bool shooting, bool timeWarp, int multiplier, 
        float growth, float time)
    {

        audio.playClip(3);
        if (growth > 1)
        {
            if (cs.getMode() == 0) //No powerups rn
            {
                cs.size(growth);
                cs.setMode(1);
                cs.playerGrowth = growth; // To reset the size once we are hit
            }
        }
        else
        {
            if (cs.getMode() == 1) //If we are currently grown
            {
                cs.setMode(2); //Set mode to other
                if (flying)
                    cs.numberOfJumps = 5;
                if (multiplier > 1)
                    cs.multiplier = multiplier;
                if (shooting)
                    StartCoroutine(FireShots());   
                if (timeWarp)
                    enemySpeed = 0.5f; //All enemies will move 1/2 speed
                
                //Start the power up timer
                powerUpTimer = time;
            }
            else if (cs.getMode() == 2) //Already powerd up but we found another, so give some more points
            {
                //TODO point addition
                cs.multiplier += multiplePointMultiplier;
            }

        }
    }

    IEnumerator FireShots()
    {
        while (cs.getMode() == 2) //While we are powered up still
        {
            Instantiate(projectile, cs.shootingPosition.position, cs.shootingPosition.rotation);
            audio.playClip(4);
            
            yield return new WaitForSeconds(shotIntervalTime); //Time between shots
        }
    }

    public float getEnemySpeed()
    {
        return enemySpeed;
    }

}

