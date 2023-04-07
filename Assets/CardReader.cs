using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    
    private string _wordsCondition1 = 
        @"
Huge
Swear
Color
Program
Octopus
Top
Mystery
Sneak
Flask
Sausage
River
Smile
Cell
Cozy
Jump";

    private string _wordsCondition2 =
        @"
User
Wall
Spicy
Lust
Dive
Sword
Bank
Bold
Mountain
Blink
Piano
Balloon
Hold
Glitter
Green";

    public List<GameObject> listOfCards;
    
    // Start is called before the first frame update
    void Start()
    {
        listOfCards = new List<GameObject>(GameObject.FindGameObjectsWithTag("Card"));
    }

    public void LoadCondition1()
    {
        LoadFromFile(_wordsCondition1);
    }

    public void LoadCondition2()
    {
        LoadFromFile(_wordsCondition2);
    }

    private void LoadFromFile(string words)
    {
        // Split the string into an array of words
        string[] wordsArray = words.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        //find every card in the scene
        listOfCards = new List<GameObject>(GameObject.FindGameObjectsWithTag("Card"));
        
        //for each card in the scene and for each card in the list 
        var i = 0;
        foreach (GameObject card in listOfCards)
        {
            card.GetComponent<FlashCard>().SetText(wordsArray[i]);
            i++;
            //if i is greater than the number of cards in the list, reset i to 0
            if (i >= wordsArray.Length)
            {
                i = 0;
            }
        }
    }
    
    public void SetTextVisibile()
    {
        foreach (GameObject card in listOfCards)
        {
            card.GetComponent<FlashCard>().SetTextVisible(true);
        }
    }
    
    public void SetTextInvisible()
    {
        foreach (GameObject card in listOfCards)
        {
            card.GetComponent<FlashCard>().SetTextVisible(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
