using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public string PieceStatus = "idle";

    public Transform edgeparticles;

    public KeyCode placepiece;
    public string checkplacement = "";
    // public Vector2 invPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PieceStatus == "pickedup")
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
        if ((Input.GetKeyDown(placepiece)) && (PieceStatus == "pickedup"))
        {

            checkplacement = "y";
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.name == gameObject.name) && (checkplacement == "y"))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = 1;
            transform.position = other.gameObject.transform.position;
            PieceStatus = "Locked";
            Instantiate(edgeparticles, other.gameObject.transform.position, edgeparticles.localRotation);
            checkplacement = "n";
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        if ((other.gameObject.name != gameObject.name) && (checkplacement == "y"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            checkplacement = "n";
        }

    }
    void OnMouseDown()
    {
        PieceStatus = "pickedup";
        checkplacement = "n";
        GetComponent<Renderer>().sortingOrder = 10;
        // invPos = transform.position;
    }

}
