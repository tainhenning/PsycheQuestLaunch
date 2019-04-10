using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setCoinText : MonoBehaviour
{
    public coinCount coins;

    private void Awake()
    {
        GetComponent<Text>().text = "Coins Collected: " + coins.coins;
    }
}
