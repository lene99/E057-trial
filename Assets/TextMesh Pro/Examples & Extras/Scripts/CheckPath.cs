//Attach this script to a GameObject
//This script outputs the Application’s path to the Console
//Run this on the target device to find the application data path for the platform
using UnityEngine;

public class CheckPath : MonoBehaviour
{
    string m_Path;

    void Start()
    {
        //Get the path of the Game data folder
        m_Path = Application.persistentDataPath;

        //Output the Game data path to the console
        Debug.Log("dataPath : " + m_Path);
    }
}