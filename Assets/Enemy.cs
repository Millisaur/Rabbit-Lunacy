using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

	public GameObject deathEffect;
	EnemySpawnerScript enemySpawn;
	[SerializeField] private float damage;

	void Start()
	{
		enemySpawn = GameObject.Find("EnemySpawner").GetComponent<EnemySpawnerScript>();
	}

	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
			FindObjectOfType<AudioManager>().Play("BunnyDeath");
		}
	}

	 void OnBecameInvisible()
	{
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			if (IsOutsideLeftView(enemy))
			{
				Die();
			}
		}
	}

	bool IsOutsideLeftView(GameObject enemy)
	{
		Vector3 enemyViewportPosition = Camera.main.WorldToViewportPoint(enemy.transform.position);

		if (enemyViewportPosition.x < 0f)
		{
			return true;
		}

		return false;
	}

	void Die ()
	{
		GameObject deathEffectObject = Instantiate(deathEffect, transform.position, Quaternion.identity);

		Destroy(deathEffectObject, 3f);

		Destroy(gameObject);
		//Debug.Log("DEATH");
		enemySpawn.counter--;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log("test");
		if(collision.gameObject.CompareTag("Player"))
		{
			collision.GetComponent<Health>().TakeDamage(damage);
		}
	}
    
}
