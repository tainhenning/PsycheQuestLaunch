using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour
{
    public string PieceStatus = "idle";

    public KeyCode placepiece;
    public string checkplacement = "";
    public Vector2 invPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*Piece will be moved along with the finger(or if left click event on mouse) after u picked it*/
        if (PieceStatus == "pickedup")
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
        /*When a piece is released by the finger or the mouse after picking it, 
         it will be redirected to its initial position of the inventory using below if loop and restored to its original color*/
        if ((Input.GetKeyUp(KeyCode.Mouse0)) && (PieceStatus == "pickedup"))
        {
            transform.position = invPos;
            GetComponent<Renderer>().sortingOrder = 1;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            PieceStatus = "";
        }
        /*PlacePiece variable is assigned to the another finger(or right click on the mouse)
         after choosing the position you want to drop the piece into,checkplacement is set to y and trigger function is called*/
        if ((Input.GetKeyDown(placepiece)) && (PieceStatus == "pickedup"))
        {

            checkplacement = "y";
        }
    }
    //Trigger function contains code of matching the names of two different objects,one is piece and the other is box collider 
    /*Trigger function is for checking whether each frame fits in correct position, if it is placed in correct position the piece is fixed,
     else the color of the piece becomes translucent*/
    void OnTriggerStay2D(Collider2D other)
    {      
        /*If both names of objects(Piece and the box collider) is matched then new position of the piece will become the position of box collider
        and it is ordered at layer 1,then piece status will be assigned as Locked*/
        if ((other.gameObject.name == gameObject.name) && (checkplacement == "y"))
        {       
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = 1;
            transform.position = other.gameObject.transform.position;
            PieceStatus = "Locked";
            checkplacement = "n";
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);//color is restored once the piece is in correct position
        }
        /*if the names don;t match the color of the piece will be reduced by half*/
        if ((other.gameObject.name != gameObject.name) && (checkplacement == "y"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);//Piece will become translucent
            checkplacement = "n";
        }
      

    }
    /*A piece is picked when u press on it using your finger(or left click on mouse) and ordered at layer(example 10 as shown here) 
     other than the layer of remaining objects so that there won't be any kind of collision 
    between the object that is picked and the objects that are idle. 
    And also while you are picking the piece at first its initial inventory position is stored in "invPos" variable*/
    void OnMouseDown()
    {
        PieceStatus = "pickedup";
        checkplacement = "n";
        GetComponent<Renderer>().sortingOrder = 10;
        invPos = transform.position;

    }
}
