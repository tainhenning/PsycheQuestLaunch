using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hasRightImage : MonoBehaviour
{
    public Sprite answer;
    public bool correct;
    Image thisImage;
    // Start is called before the first frame update
    void Start()
    {
        correct = false;
        thisImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisImage.sprite == answer) {
            correct = true;
        }
    }
}
