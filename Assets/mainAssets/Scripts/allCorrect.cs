using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allCorrect : MonoBehaviour
{
    public hasRightImage[] checks;
    public GameObject endText;
    public int allCheck;
    public int gameNumber;
    void Start()
    {
        allCheck = 2;
    }
    void Update()
    {
        bool tempCheck = true;
        for(int i  = 0; i < checks.Length; i++) {
            if(checks[i].correct == false) {
                tempCheck = false;
            }
        }
        if(tempCheck && allCheck == 2){
            allCheck -= 1;
        }
        if(allCheck == 1) {
            endText.gameObject.SetActive(true);
            if (gameNumber == 1) {
                progressionStatic.Intro1_2 = true;   
            } else {
                progressionStatic.Game1_1 = true;   
            }
            allCheck -= 1; 
        }
    }
}
