using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLoops : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Background");
        FindObjectOfType<AudioManager>().StopPlaying("Soonyee");
        FindObjectOfType<AudioManager>().StopPlaying("RachelMusic");

    }

}
