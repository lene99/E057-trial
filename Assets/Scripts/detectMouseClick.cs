using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectMouseClick : MonoBehaviour
{
    // public Text goToNextRound;
    public Text numberOfClicks;
    int counter = 0;
    //int numberOfErrors = 2;
    public GameObject errorButton1;
    public GameObject errorButton2;
    public GameObject errorButton3;

    int correctlypressed = 0;
    //public bool pressedButton = false; 

    // Update is called once per frame

    void Start()
    {

        button1pressed();
        button2pressed();
        button3pressed();
        if (correctlypressed == 3)
        {
            Debug.Log("Congratulations! You may proceed to the next round.");
        }


    }

    void button1pressed()
    {
        errorButton1.SetActive(false);
        correctlypressed++;

    }

    void button2pressed()
    {
        errorButton2.SetActive(false);
        correctlypressed++;

    }

    void button3pressed()
    {
        errorButton3.SetActive(false);
        correctlypressed++;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            numberOfClicks.color = Color.green;
            counter++;
            numberOfClicks.text = "Number of Clicks: " + counter.ToString();


        }

    }
    void OnMouseDown()
    {
        Debug.Log("Mouse is down");
    }

    void OnMouseUp()
    {
        Debug.Log("Mouse is up");
    }

    void OnMouseClick()
    {
        Debug.Log("Mouse is clicked (down then up its 1 click)");
    }
}