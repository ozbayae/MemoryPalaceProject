using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MenuManager : MonoBehaviour
{
    private int _duration = 90;
    public GameObject loadingScreen;
    public GameObject startButton;
    public CardReader cardReader;
    private bool _timerIsRunning = false;


    private void LoadingLogic()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        loadingScreen.SetActive(false);
        startButton.SetActive(true);
        cardReader.SetTextInvisible();
    }

    public void LoadCondition1()
    {
        cardReader.LoadCondition1();
        LoadingLogic();
    }
    
    public void LoadCondition2()
    {
        cardReader.LoadCondition2();
        LoadingLogic();
    }
    
    public void StartExperiment()
    {
        // Hide the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // disable the start button
        startButton.SetActive(false);
        cardReader.SetTextVisibile();
        if(_timerIsRunning == false)
        {
            _timerIsRunning = true;
            StartCoroutine(EnableMenu());
        }
    }
    
    //coroutine that enables the menu after a timer
    IEnumerator EnableMenu()
    {
        yield return new WaitForSeconds(_duration);
        loadingScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _timerIsRunning = false;
    }
}
