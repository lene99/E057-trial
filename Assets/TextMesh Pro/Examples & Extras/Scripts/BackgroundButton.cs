using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundButton : MonoBehaviour
{
    int counter = 1;
    public Text numberOfClicks;
    public clickCounter userClickButton;
    void Start()
    {
        numberOfClicks.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (userClickButton.Clicked)
        {
            Counter();
        }
    }

    public void Counter()
    {
        numberOfClicks.text = counter.ToString();
        counter++;
    }
}

