﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLoopSoonyee : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        FindObjectOfType<AudioManager>().Play("Soonyee");



    }
}
