using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    private string _pathToCardData = "Assets/Data/Test.txt";
    //list of cards: tuples of front and back
    private List<(string, string)> _cards = new List<(string, string)>();
    
    // Start is called before the first frame update
    void Start()
    {
        //read the file
        string[] lines = System.IO.File.ReadAllLines(_pathToCardData);
        //remove lines that start with #
        lines = Array.FindAll(lines, line => !line.StartsWith("#"));
        //for each line, split it into front and back
        foreach (string line in lines)
        {
            string[] split = line.Split('\t');
            //add the front and back to the list
            _cards.Add((split[0], split[1]));
        }
        //print the cards
        foreach ((string front, string back) in _cards)
        {
            Debug.Log(front + " " + back);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
