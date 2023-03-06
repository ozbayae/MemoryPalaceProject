using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashCard : MonoBehaviour
{
    private string _frontText = "This is placeholder text for the front of the card.";
    private string _backText = "This is placeholder text for the back of the card."; 
    
    private TextMesh _frontTextMesh;
    private TextMesh _backTextMesh;
    
    private float _angle = 0; // This is at what angle ( 0 - 360 ) on the panorama the card is located
    private float _distance = 5; // This is how far away from the center of the panorama the card is located, in meters
    private float _height = 0; // This is how high above the panorama the card is located, expressed as a percentage of the panorama's height
    
    bool _isFlipped = false;

// Start is called before the first frame update
    void Start()
    {
        _frontTextMesh = transform.Find("Front").GetComponent<TextMesh>();
        _backTextMesh = transform.Find("Back").GetComponent<TextMesh>();
        SetText(_frontText, _backText);
    }

    private void Update()
    {
        //billboard the card
        transform.LookAt(Camera.main.transform);
        if(_isFlipped)
        {
            transform.Rotate(0, 180, 0);
        }
    }

    public void SetText(string frontText, string backText)
    {
        _frontText = frontText;
        _backText = backText;
        
        _frontTextMesh.text = _frontText;
        _backTextMesh.text = _backText;
    }

    void OnMouseOver()
    {
        //if the right mouse button is clicked, flip the card
        if (Input.GetMouseButtonDown(1))
        {
            //flip the card
            _isFlipped = !_isFlipped;
        }
    }
}
