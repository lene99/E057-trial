using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DontDestroyAudio : MonoBehaviour
{
    public GameObject music;

    void Awake()
    {
        DontDestroyOnLoad(music);
        // add the callback method when scene loads
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    // called when scene loads
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0 && scene.buildIndex != 11)
        {
            Destroy(music);
        }
    }
}
