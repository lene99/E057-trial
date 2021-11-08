using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgMusicSoonyee : MonoBehaviour
{
    public GameObject[] music;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        // add the callback method when scene loads
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("gameMusic");
        if(music == null)
        {
            music = GameObject.FindGameObjectsWithTag("gameMusic");
        }else
        {
            Destroy(music[1]);
        }
        //Destroy(music[1]);
    }

    // called when scene loads
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex < 50 && scene.buildIndex > 62)
        {
            Destroy(transform.gameObject);
        }
        else if (scene.buildIndex == 18)
        {
            Destroy(transform.gameObject);
        }else if (scene.buildIndex == 11)
        {
            Destroy(transform.gameObject);
        }
        //if (scene.buildIndex == 11)
        //{
        //    if (music == null)
        //    {
        //        music = GameObject.FindGameObjectsWithTag("gameMusic");
        //    }
        //    else
        //    {
        //        Destroy(music[1]);
        //    }
        //}
    }
}
