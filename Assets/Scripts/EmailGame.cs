using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EmailGame : MonoBehaviour
{

    public GameObject emailImage;
    public GameObject startButton;
    public GameObject hackerHealthBar;
    public static float hackerHealth;
    public int score; 
   // float maxHealth = 100f; 
    
    void Start()
    {
        emailImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**public IEnumerator StartGame()
    {
        emailImage.SetActive(true);
        yield return new 
    }**/
}
