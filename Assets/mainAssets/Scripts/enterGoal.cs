using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterGoal : MonoBehaviour
{
    public GameObject completeScreen;
    public Transform satellite;
    public GameObject satelliteObj;
    private Transform thisTransform;

    public int unlocksGame;

    private void Start()
    {
        thisTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        if(satellite.position.x + 0.5 > thisTransform.position.x && satellite.position.x - 0.5 < thisTransform.position.x)
        {
            if(satellite.position.y + 0.5 > thisTransform.position.y && satellite.position.y - 0.5 < thisTransform.position.y)
            {
                completeScreen.SetActive(true);
                if(unlocksGame == 1) {
                    progressionStatic.Game1_1 = true;
                }
                else if(unlocksGame == 2) {
                    progressionStatic.Game1_2 = true;
                }
                else if(unlocksGame == 3) {
                    progressionStatic.Game1_3 = true;
                }
                else if(unlocksGame == 4) {
                    progressionStatic.Game2_1 = true;
                }
                Destroy(satelliteObj);
            }
        }
    }
}
