using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject music;
    // Start is called before the first frame update
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        
    }

    public void DestroyMusic(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 11 || scene.buildIndex == 18)
            Destroy(music);
    }

}
