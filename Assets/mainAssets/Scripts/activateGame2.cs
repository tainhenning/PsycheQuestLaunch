using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateGame2 : MonoBehaviour

{
    public GameObject level1_2_intro;
    public GameObject ending;
    public GameObject[] levels1;
    public GameObject[] levels2;
    public GameObject[] levels3;
    void Update()
    {

        if(progressionStatic.Intro1_2 == true) {
            level1_2_intro.SetActive(true);
        }

        if(progressionStatic.Game1_1 == true) {
            levels1[0].SetActive(true);
        }
        if(progressionStatic.Game1_2 == true) {
            levels1[1].SetActive(true);
        }
         if(progressionStatic.Game1_3 == true) {
            levels1[2].SetActive(true);
        }
                       
        if(progressionStatic.Game2_1 == true) {
            levels2[0].SetActive(true);
        }
        if(progressionStatic.Game2_2 == true) {
            levels2[1].SetActive(true);
        }
        if(progressionStatic.Game2_3 == true) {
            levels2[2].SetActive(true);
        }

        if(progressionStatic.Game3 == true) {
            for(int i = 0; i < levels3.Length; i++) {
                levels3[i].SetActive(true);
            }
        }

        if(progressionStatic.End == true) {
            ending.SetActive(true);
        }
        

    }
}
