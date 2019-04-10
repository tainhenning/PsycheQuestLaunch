using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setProgressionOnLoad : MonoBehaviour
{
    void Start() {
        progressionStatic.Game1_1 = false;
        progressionStatic.Game1_2 = false;
        progressionStatic.Game1_3 = false;
        progressionStatic.Game2_1 = false;
        progressionStatic.Game2_2 = false;
        progressionStatic.Game2_3 = false;
        progressionStatic.End = false;
        progressionStatic.Intro1_2 = false;
        progressionStatic.Game3 = false;
    }
}
