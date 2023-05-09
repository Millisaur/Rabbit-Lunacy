using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    
    public int counter = 0;

    void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player") && counter != 3)
		{   

                int randomNumber = Mathf.FloorToInt(Random.Range(0, 2));
                int randomNumber2 = Mathf.FloorToInt(Random.Range(0, 3));
                counter++;
			    Instantiate(enemyPrefabs[randomNumber], spawnPoints[randomNumber2].position, spawnPoints[randomNumber2].rotation);
		}
		//Debug.Log(counter);
	}
}
