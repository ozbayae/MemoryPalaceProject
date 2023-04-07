using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Card : MonoBehaviour
{
    private string frontText = "This is placeholder front text.";
    private string backText = "This is placeholder back text.";
    public TextMeshPro frontTextMesh;
    public TextMeshPro backTextMesh;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string front, string back)
    {
        frontText = front;
        backText = back;
        
    }
    
    
}
