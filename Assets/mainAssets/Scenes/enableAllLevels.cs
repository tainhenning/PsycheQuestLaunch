using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enableAllLevels : MonoBehaviour
{
    // Start is called before the first frame update
    public Button thisbutton;
    void Start()
    {
        thisbutton.onClick.AddListener(onClick);
    }
    void onClick() {
        progressionStatic.Game1_1 = true;
        progressionStatic.Game1_2 = true;
        progressionStatic.Game1_3 = true;
        progressionStatic.Game2_1 = true;
        progressionStatic.Game2_2 = true;
        progressionStatic.Game2_3 = true;
        progressionStatic.End = true;
        progressionStatic.Intro1_2 = true;
        progressionStatic.Game3 = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
