using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textinput : MonoBehaviour
{
    public string input;
    public GameObject inputfield;
    public GameObject textdisplay;


    public void name()
    {
        input = inputfield.GetComponent<Text>().text;
       
    }
}
