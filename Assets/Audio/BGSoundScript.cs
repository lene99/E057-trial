using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BGSoundScript : MonoBehaviour
{
    //private GameObject[] music;

    //void Start()
    //{
    //    music = GameObject.FindGameObjectsWithTag("gameMusic");
    //    Destroy(music[1]);
    //}

    //// Update is called once per frame
    //void Awake()
    //{
    //    DontDestroyOnLoad(transform.gameObject);
    //}
    public GameObject Audio; 
    void Start()
    {
        if (GameObject.FindWithTag("AudioController") == null)
        {
            Instantiate(Audio);
        }
    }

    //void Awake()
    //{
    //    if (instance != null && instance != this)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }
    //    else
    //    {
    //        instance = this;
    //    }
    //    DontDestroyOnLoad(this.gameObject);
    //}
}
