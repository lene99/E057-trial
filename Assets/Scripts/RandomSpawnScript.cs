using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnScript : MonoBehaviour
{

    public GameObject popup1, popup2; 
    public GameObject startPanel;
    public float Radius = 1;
    public float spawnRate = 2f;
    int whatToSpawn;
    float nextSpawn = 0f; 

    void Update()
    {
        if (Time.time > nextSpawn) SpawnObjectAtRandom();
        
    }

    void SpawnObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        whatToSpawn = Random.Range(1, 3);
        switch (whatToSpawn){
        case 1:
            Instantiate(popup1, randomPos, Quaternion.identity);
            break;

        case 2:
            Instantiate(popup2, randomPos, Quaternion.identity);
            break;
        }

        nextSpawn = Time.time + spawnRate; 
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Radius); 
    }

    //void OnMouseDown()
    //{
    //    Destroy(this.gameObject);
    //}

    void OnCollisionEnter(Collision other)
    {
        
            //Destroy(gameObject);
            gameObject.SetActive(false);
        
    }
}
