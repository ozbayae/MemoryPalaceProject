using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script keeps track of draggable cards and handles the logic for dragging them around
public class CardManager : MonoBehaviour
{
    //we need to know which card is being dragged
    public GameObject cardBeingDragged;

    //we need to keep a list of all the cards in the scene
    public List<GameObject> cards = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        //if we are dragging a card we need to update its position to the mouse position
        if (cardBeingDragged != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardBeingDragged.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }


    // OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider.
    void OnMouseDown()
    {
        //we need to know which card is being dragged
        //if gameobject has DraggableCard script attached
        if (gameObject.GetComponent<DraggableCard>() != null)
        {
            //set the card being dragged to this gameobject
            cardBeingDragged = gameObject;
        }
    }

    void OnMouseUp()
    {
        cardBeingDragged = null;
    }
}