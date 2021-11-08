using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingbutton : MonoBehaviour
{

    public GameObject picture;
    // Start is called before the first frame update
    void Start()
    {
        picture.SetActive(true);
    }
    void Update()
    {
        //buttonclickclick();
    }
    public void buttonclickclick()
    {
       if (picture.activeInHierarchy == true) 
        {
            picture.SetActive(false);
        }
        else
        {
            picture.SetActive(true);
        }
        
    }

}
