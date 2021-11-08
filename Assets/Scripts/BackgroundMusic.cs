using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic; 
    void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
            //DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(gameObject); 
        }
    }

    internal static void DestroyObject()
    {
        throw new NotImplementedException();
    }
}
