using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{
    public void Scene_1 ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Scene_2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void HomePage(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
        public void QuitGame ()
    {
        Debug.Log("Quit!!!");
        Application.Quit();
    }
}
