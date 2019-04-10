using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class blueprintWin : MonoBehaviour
{
    public Image[] board;
    public Image[] answers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isCorrect = true;
        for(int i = 0; i < board.Length; i++) {
            if(board[i] != answers[i]) {
                isCorrect = false;
                print(i);
                break;
            }
        }
        if(isCorrect) {
            print("!!!");
        }
    }
}
