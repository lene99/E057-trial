using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //public AudioSource tickSource; 
    private GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
       // tickSource = GetComponent<AudioSource>(); 
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       // tickSource.Play(); 
        if(collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        else if(collision.tag == "Player")
        {
            Destroy(player.gameObject);
        }
    }
}
