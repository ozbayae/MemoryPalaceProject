using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to a draggable card object, that can be dragged around the screen using the moue
public class DraggableCard : MonoBehaviour
{
    bool m_beingDragged = false;
    //reference to scriptable object that holds the card data
    public Card m_cardData;
    // Start is called before the first frame update
    void Start()
    {
        //set a child text object to the card name
        transform.GetChild(0).GetComponent<TextMesh>().text = m_cardData.front;
        //set a child text object to the card description
        transform.GetChild(1).GetComponent<TextMesh>().text = m_cardData.back;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_beingDragged)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }

    // This function is called when the mouse is clicked on the card
    // and lets the mouse drag the card around the screen
    private void OnMouseDown()
    {
        Debug.Log("Mouse down");
        //drag the card around the screen
        m_beingDragged = true;
    }
    
    // This function is called when the mouse is released
    // and stops the card from being dragged
    private void OnMouseUp()
    {
        Debug.Log("Mouse up");
        m_beingDragged = false;
    }
}
