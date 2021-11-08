using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgMusicRachel : MonoBehaviour
{
    public GameObject[] music;

    void Update()
    {
        DontDestroyOnLoad(transform.gameObject);
        // add the callback method when scene loads
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("RachelMusic");
        if (music == null)
        {
            music = GameObject.FindGameObjectsWithTag("RachelMusic");
        }
        else
        {
            Destroy(music[1]);
        }
        //Destroy(music[1]);
    }
    // called when scene loads
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 18)
        {
            Destroy(transform.gameObject);
            return;
        }else if (scene.buildIndex == 11)
        {
            Destroy(transform.gameObject);
            return;
        }
    }
   
}
